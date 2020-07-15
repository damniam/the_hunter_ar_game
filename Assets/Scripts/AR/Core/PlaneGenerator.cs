	using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;


public class PlaneGenerator : MonoBehaviour
{


    public GameObject DetectedPlanePrefab;

    private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();

    public void Update()
    {

        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        // Iterate over planes found in this frame and instantiate corresponding GameObjects to visualize them.
        Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);
        for (int i = 0; i < m_NewPlanes.Count; i++)
        {
            // Instantiate a plane visualization prefab and set it to track the new plane. The transform is set to
            // the origin with an identity rotation since the mesh for our prefab is updated in Unity World
            // coordinates.
            GameObject planeObject = Instantiate(DetectedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
            planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(m_NewPlanes[i]);
        }
    }
}
