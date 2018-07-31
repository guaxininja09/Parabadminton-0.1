using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour {
    public GameObject targetTransform;
    private Quaternion direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            //direction = Quaternion.LookRotation(targetTransform.transform.up);
            direction = targetTransform.transform.rotation;
            transform.rotation = direction;
        }
        
	}
}
