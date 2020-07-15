using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private Touch firstTouch = new Touch();

    public Camera camera;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private Vector3 originRotation;

    public float rotationSpeed = 0.5f;
    public float direction = -1;


	// Use this for initialization
	void Start ()
    {
        originRotation = camera.transform.eulerAngles;
        rotationX = originRotation.x;
        rotationY = originRotation.y;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    // chcemy wiedziec w jakies fazie jesteśmy
        foreach(Touch touch in Input.touches)
        {

            if(touch.phase == TouchPhase.Began)
            {
                firstTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                //swiping
                float deltaX = firstTouch.position.x - touch.position.x;
                float deltaY = firstTouch.position.y - touch.position.y;
                rotationX -= deltaY * Time.deltaTime * rotationSpeed * direction;
                rotationY += deltaX * Time.deltaTime * rotationSpeed * direction;
                rotationX = Mathf.Clamp(rotationX, -80f, 80f);
                camera.transform.eulerAngles = new Vector3(rotationX, rotationY, 0f);

            }
            else if(touch.phase == TouchPhase.Ended)
            {
                firstTouch = new Touch();
            }
        }
	}
}
