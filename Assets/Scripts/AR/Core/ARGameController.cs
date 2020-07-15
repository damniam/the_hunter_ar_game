using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;

public class ARGameController : MonoBehaviour
{

    private GameObject _instancedContainer;

    [SerializeField]
    public Camera FirstPersonCamera;                    // Kamera pierwszoosobowa ktora zostanie uzyta do renderowania przejść efektow kamery
    [SerializeField]
    public GameObject SurfaceDetectedModifier;              // Prefab dla szukania i pokazania płaszczyzny 
    [SerializeField]
    public GameObject Enemy;                                // Model do umieszczenia gdy uzytkownik dotknie powierzchni
    public GameObject FeaturePointPrefab;                         // Model do umieszczenia gdy użytkownik dotknie feature points


    public GameObject InstructionUI;                          // Instrukcja jak znalezc powierzchnie aparatem
    public GameObject SearchingPlaneUI;                       // Canvas który informuje że są szukane powierzchnie


    bool _placed = false;
    bool _isQuiting = false;                                 // Zwraca prawde jesli gra jest w procesie zamykania działa ARCore spowodowana błedem 
    bool _showIntructionUI = true;
    bool _showSearchingPlaneUI = true;

    private List<DetectedPlane> _allSurfaces = new List<DetectedPlane>();           // Lista do przetrzymania wszystkich wykrytych plaszczyzn

    private const float _RightRotationModel = 180.0f;    // Obrót modelu 


    public void Update()
    {
        _QuitGameOnErrors();


        Session.GetTrackables<DetectedPlane>(_allSurfaces);

        for (int i = 0; i < _allSurfaces.Count; i++)
        {
            if (_allSurfaces[i].TrackingState == TrackingState.Tracking)
            {
                _showSearchingPlaneUI = false;
                break;
            }
        }

        SearchingPlaneUI.SetActive(_showSearchingPlaneUI);

        // Jezeli uzytkownik nie dotknie ekranu, to zostatnie to zrobione tym updatem
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Raycast względem kamery a płaszczyzny, przy okazji definiujemy jakie powierzchnie będa aktywne
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if ((Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit)) && !_placed)
        {

            if ((hit.Trackable is DetectedPlane) &&
                Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                    hit.Pose.rotation * Vector3.up) < 0)
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else if (hit.Trackable is DetectedPlane)
            {
                _instancedContainer = Enemy;
            }

            var enemyObject = Instantiate(_instancedContainer, hit.Pose.position, hit.Pose.rotation);
            enemyObject.transform.Rotate(0, _RightRotationModel, 0, Space.Self);
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);
            enemyObject.transform.parent = anchor.transform;

            _placed = true;
        }
    }



    private void _QuitGameOnErrors()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Session.Status != SessionStatus.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        if (_isQuiting)
        {
            return;
        }

        // Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            _ShowAndroidToastMessage("Camera permission is needed to run this application.");
            _isQuiting = true;
            Invoke("_DoQuit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
            _isQuiting = true;
            Invoke("_DoQuit", 0.5f);
        }
    }


    private void _DoQuit()
    {
        Application.Quit();
    }


    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                    message, 0);
                toastObject.Call("show");
            }));
        }
    }

}
