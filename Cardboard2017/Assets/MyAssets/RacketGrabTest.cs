using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
public class RacketGrabTest : MonoBehaviour {

    //Leap Motion API
    public Controller controller;
    public Hand hand;
    public Frame frame;

    //Racket
    Material m_Material;
    public Material normal, grabbed;
    public Vector3 initialpos;
    public GameObject BAT;
    //Vectors & Quaternion
    public Quaternion direction;
    public Vector3 Leapdirection;
    public Vector3 LeapPosition;


    void Start () {
        controller = new Controller();
        m_Material = GetComponent<Renderer>().material;
        initialpos = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (controller.IsConnected)
        {
            frame = controller.Frame();
            hand = frame.Hands[0];

        }
        
        
            IsRacketGrabbed();
            RotateRacket();
            TranslateRacket();
        
        
	}
    private void RotateRacket()
    {
        Leapdirection = ToVector3(new Vector(-hand.PalmNormal.x, -hand.PalmNormal.z, hand.PalmNormal.y));
        transform.rotation = Quaternion.LookRotation(Leapdirection);
    }

    private void IsRacketGrabbed()
    {
        if (hand.GrabStrength == 1)
        {
            Debug.Log("grabbed");
            m_Material.color = grabbed.color;
            //transform.position = initialpos + new Vector3(hand.PalmPosition.x / 500, hand.PalmPosition.y / 500, hand.PalmPosition.z / 500);
        }
        else
        {
            m_Material.color = normal.color;
           // transform.position = initialpos;
        }
    }

    private void TranslateRacket()
    {
        LeapPosition = ToVector3(new Vector(-hand.PalmPosition.x, -hand.PalmPosition.z, 0)/100);
        transform.position =BAT.transform.position + LeapPosition;
    }
    public static Vector3 ToVector3(Vector v)
    {
        return new Vector3(v.x, v.y, v.z);
    }
}
