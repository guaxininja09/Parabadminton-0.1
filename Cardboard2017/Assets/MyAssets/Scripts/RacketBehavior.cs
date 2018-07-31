using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class RacketBehavior : MonoBehaviour {


    //Leap Motion API
    public Controller controller;
    public Hand hand;
    public Frame frame;
    public LeapQuaternion axisofhandrotation;

    //racket
    public GameObject camera;
    public Vector3 racketposition;
    public Vector3 InitialPosition;
    public Quaternion racketdirection;

    public float xdeg;
    public float ydeg;
    public float zdeg;

    void Start () {
        controller = new Controller();
        InitialPosition = transform.position;
    }
	
	
	void Update () {
        if (controller.IsConnected)
        {
            frame = controller.Frame(); 
            hand = frame.Hands[0];
            
        }
        GrabRacket();
        
    }

    void GrabRacket()
    {
        racketposition = ToVector3(hand.PalmPosition) ;
        transform.position = camera.transform.position+new Vector3(racketposition.x/200, 0, -racketposition.z/50)-new Vector3(0.0f,0.2f,0.0f);
        axisofhandrotation = hand.Rotation;
        racketdirection = Quaternion.LookRotation(ToVector3(hand.PalmNormal), transform.up);
        transform.rotation = racketdirection;
        //transform.rotation = racketdirection;
        //transform.Rotate(xdeg, ydeg, zdeg);
        //rotação

       /* if (hand.GrabStrength == 1)
        {
            
        }*/
       /*if(hand.GrabStrength!=1)
        {
            transform.position = InitialPosition;
        }*/
    }

    public static Vector3 ToVector3(Vector v)
    {
        return new Vector3(v.x, v.y, v.z);
    }
}
