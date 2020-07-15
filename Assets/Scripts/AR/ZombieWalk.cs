using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalk : MonoBehaviour {

	
	void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime * 0.1f);
        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
