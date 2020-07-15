using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeCamera : MonoBehaviour
{
    private bool gyroscopeEnabled;
    private Gyroscope gyroscope;
    private GameObject camera;
    private Quaternion rotation;

    private void Start()
    {
        camera = new GameObject("Camera Container");
        camera.transform.position = transform.position;
        transform.SetParent(camera.transform);

        gyroscopeEnabled = EnableGyroscope();
    }

    private bool EnableGyroscope()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;

            camera.transform.rotation = Quaternion.Euler(90f, 90f,0f);
            rotation = new Quaternion(0, 0, 1, 0);
            return true;
        }

        return false;
    }

    private void Update()
    {
        if(gyroscopeEnabled)
        {
            transform.localRotation = gyroscope.attitude * rotation;
        }
    }
}
