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
	}
    private void IsRacketGrabbed()
    {
        if (hand.GrabStrength == 1)
        {
            Debug.Log("grabbed");
            m_Material.color = grabbed.color;
            transform.position = initialpos + new Vector3(hand.PalmPosition.x / 500, hand.PalmPosition.y / 500, hand.PalmPosition.z / 500);
        }
        else
        {
            m_Material.color = normal.color;
            transform.position = initialpos;
        }
    }
}
