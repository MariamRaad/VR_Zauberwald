using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class HandController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean triggerAction;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2

    public GameObject wandGrip; // Wand
    public GameObject otherWand; // Wand to clone
    public bool hasWand = false;
    public bool hasWandRight = false;
    public bool hasWandLeft = false;

    private bool musicMode = false;

    public SteamVR_Input_Sources InputSource;

    private GameObject witch;
    private Animator witchAnim;
    private AudioSource witchAudio;
    private bool onboarding_index;
    private float alpha = 0.0f;
    public RawImage image_1;
    public RawImage image_2;
    public RawImage image_3;

    private GameObject ballGrip;

    public GameObject head;
    public GameObject rightHand;
    public GameObject leftHand;
    private Vector3 headPos;
    private Vector3 rightHandPos;

    private bool barrelMode = false;
    public bool activatedScoreSystem = false; //for the barrels
    public bool activatedChangeBlindness = false; //for the ChangeBlindness

    private GameObject ball;


    private void Start()
    {
        otherWand = null;
        witch = GameObject.Find("Witch");
        witchAnim = witch.GetComponent<Animator>();
        witchAudio = witch.GetComponent<AudioSource>();
        onboarding_index = false;

        head = GameObject.Find("HeadCollider");
        //Debug.Log("HeadCollider POSITION " + head.transform.position);

        headPos = head.transform.position;
        rightHandPos = rightHand.transform.position;
        //Debug.Log("ChangeBlindness " + activatedChangeBlindness);

        ball = GameObject.Find("Ball");

        //Fade out images
        image_1.CrossFadeAlpha(alpha, 0.1f, false);
        image_2.CrossFadeAlpha(alpha, 0.1f, false);
        image_3.CrossFadeAlpha(alpha, 0.1f, false);
    }

    // defines Interaction Function for/in Unity: to set GrabPinch Function
    public bool GetGrab()
    {
        return triggerAction.GetState(handType);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Debug.Log("hasWand " + hasWand); // never returns to false again
        if (!musicMode)
        {
            Debug.Log("collidingobject " + collidingObject);

            /*
            if (ballGrip) // or ballGrip
            {
                while (SteamVR_Actions._default.Squeeze.GetAxis(InputSource) >= 0.7)
                {
                   Debug.Log("Trigger ist gedrückt größer 0.7");
                   GrabObject();
                }
            }
            //

            Debug.Log("HeadPos: " + headPos);
            Debug.Log("RightHandPos: " + rightHandPos);

            if (rightHandPos.z - 20 < headPos.z)
            {
                Debug.Log("CHANGE BLINDNESS!");
            }

            if (triggerAction.GetLastStateDown(handType))
            {
                if (wandGrip)
                {
                    if (hasWand)
                    {
                        // change Hand/Controller that holds the Wand to other Hand/Controller if Trigger Button is pressed
                        hasWand = false;
                        GrabWand();
                    }
                    else
                    {
                        GrabWand();
                    }
                }

                if (ballGrip) // or ballGrip
                {
                    //while (SteamVR_Actions._default.Squeeze.GetAxis(InputSource) >= 0.7)
                    //{
                        //Debug.Log("Trigger ist gedrückt größer 0.7");
                        GrabObject();
                    //}
                }
            }

            // 2
            // needed for throwing the Ball 
            if (triggerAction.GetLastStateUp(handType))
            {
                if (objectInHand == ballGrip) //objectInHand == 
                {
                    ReleaseObject();
                }
            }
        }
        */

    }

    private void FixedUpdate()
    {
        //Debug.Log("hasWand " + hasWand); // never returns to false again
        if (!musicMode)
        {
            //Debug.Log("collidingobject " + collidingObject);

            /*
            if (ballGrip) // or ballGrip
            {
                while (SteamVR_Actions._default.Squeeze.GetAxis(InputSource) >= 0.7)
                {
                   Debug.Log("Trigger ist gedrückt größer 0.7");
                   GrabObject();
                }
            }
            */

            /*
            if (activatedChangeBlindness)
            {
                Debug.Log("CHANGE BLINDNESS!");

                if (hasWandLeft)
                {
                    ball.transform.parent = GameObject.Find("LeftHand").gameObject.transform;
                    ball.transform.localPosition = new Vector3(0, 0, -0.090f);
                    ball.transform.localRotation = Quaternion.Euler(0, 90, 90);
                    GameObject.Find("LeftHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
                    //Set Controller invisible, to only see the Wand
                    //SetControllerVisible(GameObject.Find("LeftHand"), false);
                }
                else if (hasWandRight)
                {
                    ball.transform.parent = GameObject.Find("RightHand").gameObject.transform;
                    ball.transform.localPosition = new Vector3(0, 0, -0.090f);
                    ball.transform.localRotation = Quaternion.Euler(0, 90, 90);
                    GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
                    //Set Controller invisible, to only see the Wand
                    //SetControllerVisible(GameObject.Find("RightHand"), false);
                }
            }
            */
            if (!barrelMode)
            {
                if (triggerAction.GetLastStateDown(handType))
                {
                    if (wandGrip)
                    {
                        if (hasWand)
                        {
                            // change Hand/Controller that holds the Wand to other Hand/Controller if Trigger Button is pressed
                            hasWand = false;
                            GrabWand();
                        }
                        else
                        {
                            GrabWand();
                        }
                    }

                    if (ballGrip) // or ballGrip
                    {
                        //while (SteamVR_Actions._default.Squeeze.GetAxis(InputSource) >= 0.7)
                        //{
                        //Debug.Log("Trigger ist gedrückt größer 0.7");
                        //GrabObject();
                        //}
                    }
                }

                // 2
                // needed for throwing the Ball 
                if (triggerAction.GetLastStateUp(handType))
                {
                    if (objectInHand == ballGrip) //objectInHand == 
                    {
                        //ReleaseObject();
                    }
                }
            }
        }
    }

    // 1 General Check if objects are triggered
    public void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Trigger Enter: " + col.gameObject.name);
        SetCollidingObject(col);


        // Special Case for Drums
        if (col.gameObject.name == "Drums" || col.gameObject.name == "Xylophone")
        {
            musicMode = true;
            // give Player a second Wand
            if (hasWand)
            {
                //Debug.Log("Spieler hat schon 1 Zauberstab");
                // Player already has Wand in Right Hand
                if (hasWandRight)
                {
                    hasWandLeft = true;

                    // Create another Wand in his Left Hand
                    otherWand = Instantiate(wandGrip);
                    otherWand.transform.parent = GameObject.Find("LeftHand").gameObject.transform;
                    otherWand.transform.localPosition = new Vector3(0, 0, -0.090f);
                    otherWand.transform.localRotation = Quaternion.Euler(0, 90, 90);
                    GameObject.Find("LeftHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
                    //Set Controller invisible, to only see the Wand
                    SetControllerVisible(GameObject.Find("LeftHand"), false);
                }
                // Player already has Wand in Left Hand
                else if (hasWandLeft)
                {
                    hasWandRight = true;

                    // Create another Wand in his Right Hand
                    otherWand = Instantiate(wandGrip);
                    otherWand.transform.parent = GameObject.Find("RightHand").gameObject.transform;
                    otherWand.transform.localPosition = new Vector3(0, 0, -0.090f);
                    otherWand.transform.localRotation = Quaternion.Euler(0, 90, 90);
                    GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
                    //Set Controller invisible, to only see the Wand
                    SetControllerVisible(GameObject.Find("RightHand"), false);
                }
            }
        }

        // Special Case for Onboarding
        if ((col.gameObject.name == "Table_Onboarding") & (onboarding_index == false)) // & onboarding_index == 0
        {
            // Show Witch
            witchAnim.SetTrigger("Active");
            witchAnim.Play("Witch");
            // Play its Audio
            witchAudio.Play();

            //Fade in images
            image_1.CrossFadeAlpha(1.0f, 5f, false);
            image_2.CrossFadeAlpha(1.0f, 5f, false);
            image_3.CrossFadeAlpha(1.0f, 5f, false);
            onboarding_index = true;
        }
        else if ((col.gameObject.name == "Table_Onboarding") & (onboarding_index == true))
        {
            // Spiele keine Animationen ab, aber spiele Audio erneut
            witchAudio.Play();

            onboarding_index = true;
        }
        else if ((col.gameObject.name == "Book") & (onboarding_index == true))
        {
            // Spiele keine Animationen ab, aber spiele Audio erneut
            witchAudio.Play();

            onboarding_index = true;
        }

        // Special Case for Barrels
        else if (col.gameObject.name == "Barrels")
        {
            barrelMode = true;
            activatedScoreSystem = true;
            Debug.Log("ScoreSystem " + activatedChangeBlindness);

            if (hasWand)
            {
                if (hasWandRight)
                {
                    wandGrip.SetActive(false);
                    GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = true;
                    //Set Controller invisible, to only see the Wand
                    SetControllerVisible(GameObject.Find("RightHand"), true);
                    hasWandRight = false;
                }
                else if (hasWandLeft)
                {
                    wandGrip.SetActive(false);
                    GameObject.Find("LeftHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = true;
                    //Set Controller invisible, to only see the Wand
                    SetControllerVisible(GameObject.Find("LeftHand"), true);
                    hasWandLeft = false;
                }
            }


        }

        // Special Case for Change Blindness
        else if (col.gameObject.name == "HeadCollider")
        {
            activatedChangeBlindness = true;
            //Debug.Log("ChangeBlindness " + activatedChangeBlindness);
        }

    }

    // 2
    public void OnTriggerStay(Collider col)
    {
        //SetCollidingObject(col);
    }

    // 3
    public void OnTriggerExit(Collider col)
    {
        //Debug.Log("Trigger Exit: " + col.gameObject.name);
        if (!collidingObject)
        {
            return;
        }
        //collidingObject = null;


        if (col.gameObject.name == "Drums" || col.gameObject.name == "Xylophone")
        {
            musicMode = false;
            //Debug.Log("EXIT");
            if (hasWand)
            {
                //Debug.Log("hasWand yes");
                if (hasWandRight & hasWandLeft)
                {
                    //Debug.Log("hasWand in both hands");
                    if (otherWand != null)
                    {
                        // delete the Wand that was created before
                        Destroy(otherWand, 0.01f);

                        //toggle visibility of the controller
                        if (hasWandRight)
                        {
                            GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
                            //Set Controller invisible, to only see the Wand
                            SetControllerVisible(GameObject.Find("RightHand"), false);

                            GameObject.Find("LeftHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = true;
                            //Set Controller invisible, to only see the Wand
                            SetControllerVisible(GameObject.Find("LeftHand"), true);
                        }
                        else if (hasWandLeft)
                        {
                            GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = true;
                            //Set Controller invisible, to only see the Wand
                            SetControllerVisible(GameObject.Find("RightHand"), true);

                            //Wand will always be in the right Hand, and in the left Hand will be the controller
                            GameObject.Find("LeftHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
                            //Set Controller invisible, to only see the Wand
                            SetControllerVisible(GameObject.Find("LeftHand"), false);
                        }
                        
                        hasWandRight = true;
                        hasWandLeft = false;
                        //Debug.Log("deleted other wand");
                        //Debug.Log("otherWand " + otherWand);
                    }

                }
            }
        }

        // Special Case for Barrels
        if (col.gameObject.name == "Barrels")
        {
            barrelMode = false;
            activatedScoreSystem = false;
            //Debug.Log("ScoreSystem " + activatedChangeBlindness);
            
            //Wand will always be in the right Hand, and in the left Hand will be the controller
            wandGrip.SetActive(true);
            GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
            //Set Controller invisible, to only see the Wand
            SetControllerVisible(GameObject.Find("RightHand"), false);
            hasWandRight = true;
            hasWandLeft = false;

        }

        // Special Case for Change Blindness
        if (col.gameObject.name == "HeadCollider")
        {
            activatedChangeBlindness = false;
            //Debug.Log("ChangeBlindness " + activatedChangeBlindness);
        }

    }

    // Specific Check if object is Wand
    private void SetCollidingObject(Collider col)
    {
        if (col.gameObject.tag.Equals("Wand"))
        {
            //Debug.Log(col + "Controller collided with Wand");

            // Set Wand
            wandGrip = col.gameObject;
        }

        else if (col.gameObject.tag.Equals("Ball"))
        {
            ballGrip = col.gameObject;
        }

        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            // do nothing
        }
        else
        {
            collidingObject = col.gameObject;
        }
    }

    // Pick Up the Wand
    private void GrabWand()
    {
        hasWand = true;
        wandGrip.gameObject.transform.parent = this.gameObject.transform;

        //Set the Hand/Glove Position where it should hold the Wand
        wandGrip.transform.localPosition = new Vector3(0, 0, -0.090f);
        wandGrip.transform.localRotation = Quaternion.Euler(0, 90, 90);

        this.gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;

        //Set Controller invisible, to only see the Wand
        SetControllerVisible(this.gameObject, false);


        if (wandGrip.transform.parent.name == "RightHand")
        {
            //Debug.Log("RECHTE Hand hat Zauberstab");
            hasWandRight = true;
            hasWandLeft = false;

            //Controller einblenden
            GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
            //Set Controller invisible, to only see the Wand
            SetControllerVisible(GameObject.Find("RightHand"), false);
            GameObject.Find("LeftHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = true;
            //Set Controller invisible, to only see the Wand
            SetControllerVisible(GameObject.Find("LeftHand"), true);
        }
        else if (wandGrip.transform.parent.name == "LeftHand")
        {
            //Debug.Log("LINKE Hand hat Zauberstab");
            hasWandRight = false;
            hasWandLeft = true;

            //Controller einblenden
            GameObject.Find("LeftHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;
            //Set Controller invisible, to only see the Wand
            SetControllerVisible(GameObject.Find("LeftHand"), false);
            GameObject.Find("RightHand").gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = true;
            //Set Controller invisible, to only see the Wand
            SetControllerVisible(GameObject.Find("RightHand"), true);
        }

    }

    //Pick Up any other Object than the Wand: here it is the Ball
    private void GrabObject()
    {
        // 1
        objectInHand = ballGrip;//collidingObject;
        //collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        Debug.Log("objectInHand " + objectInHand.name);
        Debug.Log("collidingObject " + collidingObject.name);
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        /*
        ballGrip.gameObject.transform.parent = this.gameObject.transform;

        //Set the Hand/Glove Position where it should hold the Ball
        ballGrip.transform.localPosition = new Vector3(0, 0, 0f);
        ballGrip.transform.localRotation = Quaternion.Euler(0, 90, 90);

        this.gameObject.GetComponent<Valve.VR.InteractionSystem.Hand>().enabled = false;

        //Set Controller invisible, to only see the Ball
        //SetControllerVisible(this.gameObject, false);
        */
    }

    void SetControllerVisible(GameObject controller, bool visible)
    {
        foreach (SteamVR_RenderModel model in controller.GetComponentsInChildren<SteamVR_RenderModel>())
        {
            foreach (var child in model.GetComponentsInChildren<MeshRenderer>())
                child.enabled = visible;
        }
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fxJoint = gameObject.AddComponent<FixedJoint>(); //Controller gets fixedJoint
        //FixedJoint fxJoint = gameObject.GetComponent<FixedJoint>();
        fxJoint.breakForce = 20000;
        fxJoint.breakTorque = 20000;
        return fxJoint;
    }

    //needed for throwing the Ball
    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3 get the velocity and angle from the controller/player

            //objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity() * 1.2f; //* 1.2f
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity() * -1f;

            /*
            //Transform.Vector takes World Coordinates, not local
            objectInHand.GetComponent<Rigidbody>().velocity = gameObject.transform.TransformVector(controllerPose.GetVelocity()); // * 0.25f
            objectInHand.GetComponent<Rigidbody>().velocity = gameObject.transform.TransformVector(controllerPose.GetAngularVelocity()); // * -0.5f
            */
            //objectInHand.GetComponent<Rigidbody>().maxAngularVelocity = objectInHand.GetComponent<Rigidbody>().angularVelocity.magnitude;

            //Debug.Log("Ball velocity" + objectInHand.GetComponent<Rigidbody>().velocity);
            //Debug.Log("Ball angular" + objectInHand.GetComponent<Rigidbody>().angularVelocity);

        }
        // 4
        objectInHand = null;
        ballGrip = null;
    }
}
