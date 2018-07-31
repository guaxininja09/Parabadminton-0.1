using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
public class LeapRacket : MonoBehaviour {
    public GameObject player;
    //Leap API
    public Controller controller;
    public Hand hand;
    public Frame frame;
    public float scale;
    public Vector3 test;

    private Quaternion racketdirection;
    // Use this for initialization
    void Start () {
        controller = new Controller();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller.IsConnected)
        {
            frame = controller.Frame();
            hand = frame.Hands[0];

        }
        
        test = new Vector3(hand.PalmPosition.x / 500, hand.PalmPosition.y / 500, -hand.PalmPosition.z / 500);
            transform.position = player.transform.position + test ;

        racketdirection = Quaternion.LookRotation(ToVector3(hand.Direction), transform.up);
        transform.rotation = racketdirection;
    }
    
    public static Vector3 ToVector3(Vector v)
    {
        return new Vector3(v.x, v.y, v.z);
    }
}
