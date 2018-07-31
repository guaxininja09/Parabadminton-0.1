using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognition : MonoBehaviour {

    //Hand bones
    public GameObject palm;
    //public GameObject indexb1;
   // public GameObject indexb2;
    public GameObject indexb3;
    //public GameObject middleb1;
   // public GameObject middleb2;
    public GameObject middleb3;


    //Bones positions
    public Vector3 palmPos;
    //public Vector3 indexb1Pos;
   // public Vector3 indexb2Pos;
    public Vector3 indexb3Pos;

    //public Vector3 middleb1Pos;
    //public Vector3 middleb2Pos;
    public Vector3 middleb3Pos;


    //Distances
    public float indextopalm;
    public float middletopalm;

    //bools
    public bool recognition;
    public bool grip;

    //direção da palma
 
    //sphere
    public Rigidbody rb;
    Material m_Material;


    //Others

    public float thresh;
    public Vector3 currentrotation;
    public Vector3 postrotation;
    public float currCountdownValue;
    public Vector3 posi;
    public Vector3 posf;
    public Vector3 palmspeed;
    public float boundary;

    //direções
    public enum Direction {negative, zero, positive};
    public Direction xvel;
    public Direction yvel;
    public Direction zvel;

    //rotação
     enum Turn {anticlockwise, stopped, clockwise }
     Turn xrot;
     Turn yrot;
     Turn zrot;


    // public GameObject cube;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        m_Material = GetComponent<Renderer>().material;
        StartCoroutine(StartCountdown());
        xvel = Direction.zero;
        yvel = Direction.zero;
        zvel = Direction.zero;
    }

    // Update is called once per frame
    void Update () {
        
        DetectPos();
        
        RecognizeGesture();
        if (recognition == true && grip==true)
        {
            SphereAction();
        }
        if (currCountdownValue == 0)
        {
            recognition = false;
            StartCoroutine(StartCountdown());
        }

        //currentrotation = new Vector3(palm.transform.rotation.x, palm.transform.rotation.y, palm.transform.rotation.z);     
        
    }

    public void SphereAction()
    {
        //direcao x
        if (xvel == Direction.positive)
        {
            rb.AddForce(0.03f,0.0f,0.0f,ForceMode.Impulse);
        }
        if (xvel == Direction.negative)
        {
            rb.AddForce(-0.03f, 0.0f, 0.0f,ForceMode.Impulse);

        }
        //direcao z
        if (zvel == Direction.positive)
        {
            rb.AddForce(0.0f, 0.0f, 0.03f,ForceMode.Impulse);
        }
        if (xvel == Direction.negative)
        {
            rb.AddForce(0.0f, 0.0f, -0.03f,ForceMode.Impulse);
        }
        //direcao y
        if (yvel == Direction.positive)
        {
            rb.AddForce(0.0f, 0.025f, 0.0f, ForceMode.Impulse);
        }
        if (xvel == Direction.negative)
        {
            rb.AddForce(0.0f, 0.025f, 0.0f, ForceMode.Impulse);
        }

    }

    //Contador
    public IEnumerator StartCountdown(float countdownValue =5)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSecondsRealtime(0.1f);
            currCountdownValue--;
         

        }
    }
    //Reconhece os gestos e altera as booleanas correspondentes.
    private void RecognizeGesture()
    {   
        // Detecta grip
        if (indextopalm <= 0.05 && middletopalm <= 0.05)
        {
            grip = true;
          
            
        }
        else
        {
            grip = false;
        }

        if (grip == true)
        {
            m_Material.color = Color.red;
        }
        else
        {
            m_Material.color = Color.cyan;
        }

        // Detecta hand turn
        if (currCountdownValue == 4)
        {
            currentrotation = new Vector3(palm.transform.rotation.x, palm.transform.rotation.y, palm.transform.rotation.z);
            posi = palm.transform.position;
            
        }
        if (currCountdownValue == 1)
        {
            //rotacao
            postrotation = new Vector3(palm.transform.rotation.x, palm.transform.rotation.y, palm.transform.rotation.z);
            if (recognition == false)
            {
                if (Mathf.Abs(postrotation.x - currentrotation.x) > 0.10 && postrotation.x > 0 && currentrotation.x > 0)
                {
                    Debug.Log("xturn");
                }
                if (Mathf.Abs(postrotation.y - currentrotation.y) > 0.10 && postrotation.y > 0 && currentrotation.y > 0)
                {
                    Debug.Log("yturn");
                }
                if (Mathf.Abs(postrotation.z - currentrotation.z) > 0.10 && postrotation.z > 0 && currentrotation.z > 0)
                {
                    Debug.Log("zturn");
                }
     
                //deslocamento
                posf = palm.transform.position;
                palmspeed = posf - posi;
                //direções do deslocamento
                //deslocamento em x
                if (palmspeed.x > 0.1)
                {
                    Debug.Log("vel+x");
                    xvel = Direction.positive;
                }
                if (-0.1 < palmspeed.x && palmspeed.x < 0.1)
                {
                    Debug.Log("vel0x");
                    xvel = Direction.zero;
                }
                if (palmspeed.x < -0.1)
                {
                    Debug.Log("vel-x");
                    xvel = Direction.negative;
                }

                //deslocamento em y
                if (palmspeed.y > 0.1)
                {
                    Debug.Log("vel+y");
                    yvel = Direction.positive;
                }
                if (-0.1 < palmspeed.y && palmspeed.y < 0.1)
                {
                    Debug.Log("vel0y");
                    yvel = Direction.zero;
                }
                if (palmspeed.y < -0.1)
                {
                    Debug.Log("vel-y");
                    yvel = Direction.negative;
                }

                //deslocamento em z
                if (palmspeed.z > 0.1)
                {
                    Debug.Log("vel+z");
                    zvel = Direction.positive;
                }
                if (-0.1 < palmspeed.z && palmspeed.z < 0.1)
                {
                    Debug.Log("vel0z");
                    zvel = Direction.zero;
                }
                if (palmspeed.z < -0.1)
                {
                    Debug.Log("vel-z");
                    zvel = Direction.negative;
                }
                recognition = true;
            }
           

        }

    }

    //detecta a posição de cada osso
    private void DetectPos()
    {
    

     palmPos= palm.transform.position;
     //indexb1Pos= indexb1.transform.position;
     //indexb2Pos= indexb2.transform.position;
     indexb3Pos= indexb3.transform.position;
    // middleb1Pos= middleb1.transform.position;
     //middleb2Pos= middleb2.transform.position;
     middleb3Pos = middleb3.transform.position;

        indextopalm = Vector3.Distance(palmPos, indexb3Pos);
        middletopalm = Vector3.Distance(palmPos, middleb3Pos);
    }





    private void RecHigh()
    {
        if (palm.transform.position.y >= thresh)
        {
            Debug.Log("high");
        }
        if (palm.transform.position.y < thresh)
        {
            Debug.Log("low");
        }
    }
}
