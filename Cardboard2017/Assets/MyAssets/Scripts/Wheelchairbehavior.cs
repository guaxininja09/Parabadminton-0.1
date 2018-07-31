using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelchairbehavior : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
   // private Quaternion wheelchairRotation;
    public Vector3 cameraXZ;
    public GameObject camera;
   // public float OffsetAngle;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        cameraXZ = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.forward.x, 0, GameObject.FindGameObjectWithTag("MainCamera").transform.forward.z);

        if (Input.GetAxis("Vertical") > 0.01)
        {
            Debug.Log("Frente");
            //rb.AddForce(transform.forward * speed,ForceMode.VelocityChange);
            rb.AddForce(cameraXZ * speed, ForceMode.VelocityChange);
        }
        else if (Input.GetAxis("Vertical") < -0.01)
        {
            Debug.Log("Tras");
            //rb.AddForce(transform.forward * -speed, ForceMode.VelocityChange);
            rb.AddForce(-cameraXZ * speed, ForceMode.VelocityChange);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        cameraXZ = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.forward.x, 0, GameObject.FindGameObjectWithTag("MainCamera").transform.forward.z);
    }
}
