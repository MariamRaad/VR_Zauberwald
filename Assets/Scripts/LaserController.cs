using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    private bool gripRight;
    private bool gripLeft;

    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4
    private Vector3 fwd;
    private float distance;

    protected GameObject hitObject;
    protected RaycastHit rayHit;
    public SteamVR_Action_Boolean triggerAction;

    private GameObject treeScript;
    private GameObject mushroomhouseScript;
    private GameObject bubblesScript;
    private GameObject fireScript;
    private GameObject roosterScript;
    private GameObject flyingObjectScript;

    public HandController handScript;

    private bool laserRight = false;
    private bool laserLeft = false;

    public SteamVR_Input_Sources InputSource;
    private GameObject flyingObject;

    public bool isCarrying = false;

    //This is a refrence to the object we want the pointer to be casted from
    [SerializeField]
    public Transform controllerRef;

    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;

        gripRight = false;
        gripLeft = false;

        mushroomhouseScript = GameObject.Find("mushroom_house");
        bubblesScript = GameObject.Find("Flower_Bubble");
        fireScript = GameObject.Find("Campfire");
        roosterScript = GameObject.Find("Rooster");
        //flyingObjectScript = GameObject.Find("FlyingObjectController");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("gripRight " + gripRight);
        //Debug.Log("gripLeft " + gripLeft);

        ToggleLaserPointerAfterHandChanged();

        if (handScript.hasWandRight)
        {
            //Debug.Log("HASWAND Right " + handScript.hasWandRight);

            // welcher parent hat wandgrip --> ob rechts/links handScript.wandGrip.transform.parent.name == "RightHand" || handType.Equals("RightHand")
            if (handScript.wandGrip.transform.parent.name == "RightHand")
            {
                //Debug.Log("PARENT RIGHT");

                ToggleGripButtonRight();

                // 1
                if (gripRight)
                {
                    //Debug.Log("Laser is active");
                    laser.SetActive(true);
                    laserRight = true;
                    laserLeft = false;

                    //Debug.Log("SHOW LASER");
                    RaycastHit hit;
                    //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                    //Debug.DrawRay(transform.position, forward, Color.green);

                    // 2
                    if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 50))
                    {
                        hitPoint = hit.point;
                        fwd = transform.forward;
                        //distance = hit.distance;
                        //Debug.Log(hit.transform.name + " wurde getroffen");
                        ShowLaser(hit);
                        Interactions(hit);
                    }
                }

                if (!gripRight || gripLeft)
                {
                    //Debug.Log("Laser is NOT active");
                    laser.SetActive(false);
                }
            }
        }
        else if (handScript.hasWandLeft)
        {
            if (handScript.wandGrip.transform.parent.name == "LeftHand")
            {
                //Debug.Log("PARENT LEFT");

                ToggleGripButtonLeft();

                // 1
                if (gripLeft)
                {
                    //Debug.Log("Laser is active");
                    laser.SetActive(true);
                    laserRight = false;
                    laserLeft = true;

                    //Debug.Log("SHOW LASER");
                    RaycastHit hit;
                    //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                    //Debug.DrawRay(transform.position, forward, Color.green);

                    // 2
                    if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 50))
                    {
                        hitPoint = hit.point;
                        //Debug.Log(hit.transform.name + " wurde getroffen");
                        ShowLaser(hit);
                        Interactions(hit);
                    }
                }

                if (!gripLeft || gripRight)
                {
                    //Debug.Log("Laser is NOT active");
                    laser.SetActive(false);
                }
            }
        }
    }


    /*
        ToggleGripButton();

        // 1
        if (grip)
        {
            //Debug.Log("Laser is active");
            laser.SetActive(true);

            Debug.Log("SHOW LASER");
            RaycastHit hit;
            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            //Debug.DrawRay(transform.position, forward, Color.green);

            // 2
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                //Debug.Log(hit.transform.name + " wurde getroffen");
                ShowLaser(hit);

                if (hit.transform.tag == "Tree") // Find any Tree
                {
                    treeScript = GameObject.Find(hit.transform.name); // Find the specific Tree by its Name
                    if (triggerAction.GetLastStateDown(handType))
                    {
                        treeScript.GetComponent<TreeController>().interactWithTree(); // Get the Method of its specific Script
                    }
                }
                else if (hit.transform.name == "mushroom_house")
                {
                    if (triggerAction.GetLastStateDown(handType))
                    {
                        mushroomhouseScript.GetComponent<HouseController>().interactWithHouse();
                    }
                }
                else if (hit.transform.name == "Flower_Bubble")
                {
                    if (triggerAction.GetLastStateDown(handType))
                    {
                        bubblesScript.GetComponent<BubbleController>().interactWithBubbles();
                    }
                }
            }
        }

    */


    private void ShowLaser(RaycastHit hit)
    {
        // 1
        //laser.SetActive(true);

        // 2
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }

    private void ToggleGripButton()
    {
        if (grabAction.GetState(handType) && (!gripRight || !gripLeft))
        {
            if (handType.Equals("RightHand"))
            {
                //Debug.Log("GRIP Right" + gripRight);
                gripRight = true;
            }
            else if (handType.Equals("LeftHand"))
            {
                //Debug.Log("GRIP Left" + gripLeft);
                gripLeft = true;
            }
        }
        else if (grabAction.GetState(handType) && (gripRight || gripLeft))
        {
            if (handType.Equals("RightHand"))
            {
                //Debug.Log("GRIP Right" + gripRight);
                gripRight = false;
            }
            else if (handType.Equals("LeftHand"))
            {
                //Debug.Log("GRIP Left" + gripLeft);
                gripLeft = false;
            }

        }
    }


    private void ToggleGripButtonRight()
    {
        if (grabAction.GetState(SteamVR_Input_Sources.RightHand) && !gripRight)
        {
            //Debug.Log("GRIP Right" + gripRight);
            gripRight = true;
        }
        else if (grabAction.GetState(SteamVR_Input_Sources.RightHand) && gripRight)
        {
            //Debug.Log("GRIP Right" + gripRight);
            gripRight = false;
        }
    }

    private void ToggleGripButtonLeft()
    {
        if (grabAction.GetState(SteamVR_Input_Sources.LeftHand) && !gripLeft)
        {
            //Debug.Log("GRIP LEFT" + gripLeft);
            gripLeft = true;
        }
        else if (grabAction.GetState(SteamVR_Input_Sources.LeftHand) && gripLeft)
        {
            //Debug.Log("GRIP LEFT" + gripLeft);
            gripLeft = false;
        }
    }


    private void ToggleLaserPointerAfterHandChanged()
    {
        //Debug.Log("Toggle Hand Changed");
        if (laserRight)
        {
            //Debug.Log("Toggle Laser Right");
            laser.SetActive(false);
        }
        else if (laserLeft)
        {
            //Debug.Log("Toggle Laser Left");
            laser.SetActive(false);
        }
    }


    private void Interactions(RaycastHit hit)
    {
        if (hit.transform.tag == "Tree") // Find any Tree
        {
            treeScript = GameObject.Find(hit.transform.name); // Find the specific Tree by its Name
            if (triggerAction.GetLastStateDown(handType))
            {
                treeScript.GetComponent<TreeController>().InteractWithTree(); // Get the Method of its specific Script
            }
        }
        else if (hit.transform.name == "mushroom_house")
        {
            if (triggerAction.GetLastStateDown(handType))
            {
                mushroomhouseScript.GetComponent<HouseController>().InteractWithHouse();
            }
        }
        else if (hit.transform.name == "Flower_Bubble")
        {
            if (triggerAction.GetLastStateDown(handType))
            {
                bubblesScript.GetComponent<BubbleController>().InteractWithBubbles();
            }
        }
        else if (hit.transform.name == "Campfire")
        {
            if (triggerAction.GetStateDown(handType))
            {
                fireScript.GetComponent<FireController>().InteractWithFire();
            }
        }
        else if (hit.transform.name == "Rooster")
        {
            if (triggerAction.GetStateDown(handType))
            {
                roosterScript.GetComponent<RoosterController>().InteractWithRooster();
            }
        }
        else if (hit.transform.name == "Bush_1") //tag == "FlyingObject"
        {
            flyingObject = GameObject.Find("Bush_1");//hit.transform.name
            Debug.Log("Flugobjekt " + flyingObject.name);
            
            if (SteamVR_Actions._default.Squeeze.GetAxis(InputSource) >= 0.7) // (SteamVR_Actions._default.Squeeze.GetAxis(InputSource) >= 0.7)
            //if (triggerAction.GetLastStateDown(handType))
            //if (triggerAction.GetStateDown(handType))
            {
                Debug.Log("SQUEEZE");
                // pick up and carry object
                // attach object to hit point of the raycast
                // and move it around with it
                // Objekt wird an Endpunkt des Lasers gesetzt
                // object will be set to laser endpoint/hitpoint
                // laser has defined distance
                // idea: child is flyingObject --> follows the controller which is parent --> within the hit.distance

                Vector3 target = hit.point;
                //target = controllerPose.transform.position;
                //flyingObject = GameObject.Find("Bush_1");


                flyingObject.transform.parent = controllerRef.transform.parent;
                //flyingObject.transform.localRotation = Quaternion.identity;

                float targetDistance = Vector3.Distance(controllerRef.transform.position, flyingObject.transform.position);
                Debug.Log("TargetDistance " + targetDistance);

                //flyingObject.GetComponent<Rigidbody>().isKinematic = true;
                flyingObject.transform.position = Vector3.Lerp(flyingObject.transform.position, (controllerRef.position + targetDistance * controllerRef.forward), Time.deltaTime * 4); //distance*controllerRef.forward
                
                isCarrying = true;

            }

            else if (triggerAction.GetLastStateUp(handType)) //  Squeeze.GetAxis(InputSource) <= 0.3) //triggerAction.GetLastStateUp(handType)  SteamVR_Actions._default.Squeeze.GetAxis(InputSource) <= 0.3
            {
                //let object fall to the ground
                //flyingObject.GetComponent<Rigidbody>().isKinematic = false; //with Kinematic off it wall fall through the ground


                /*
                Vector3 startPos = flyingObject.transform.position;
                float howHigh = flyingObject.transform.position.y;
                Vector3 endPos = flyingObject.transform.position + Vector3.down * howHigh;
                Vector3 groundedPos = new Vector3(flyingObject.transform.position.x, 0.01f, flyingObject.transform.position.z);

                Debug.Log("y distanz " + howHigh);

                //too fast
                //flyingObject.transform.position = Vector3.MoveTowards(flyingObject.transform.position, groundedPos, 500f * Time.deltaTime);

                flyingObject.transform.position = Vector3.Lerp(startPos, groundedPos, Time.deltaTime * 4);

                /*
                if (flyingObject.transform.position.y > 0.01f)
                {
                    flyingObject.transform.Translate(Vector3.down * Time.deltaTime * 4);
                }
                */


                isCarrying = false;
                flyingObject.transform.parent = null;



                flyingObjectScript = GameObject.Find(hit.transform.name); // Find the specific Object by its Name
                flyingObjectScript.GetComponent<FlyingObjectController>().InteractWithFlyingObjects();



                //flyingObject = null;
            }



        }
    }

}
