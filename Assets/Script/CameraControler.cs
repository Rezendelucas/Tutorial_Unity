using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public Transform target;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.3f;


	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vector = Vector3.SmoothDamp(transform.position, target.position,ref velocity, smoothTime);
        transform.position = new Vector3(vector.x,transform.position.y, transform.position.z);
	}
}
