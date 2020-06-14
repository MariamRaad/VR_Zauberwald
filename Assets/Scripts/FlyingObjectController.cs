using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FlyingObjectController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    public LaserController script;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        /*
        if (script.isCarrying == false)
        {
            //if (gameObject.transform.position.y > 0.1f)
            //{
            Vector3 startPos = gameObject.transform.position;
            Vector3 groundedPos = new Vector3(gameObject.transform.position.x, 0.01f, gameObject.transform.position.z);

            gameObject.transform.position = Vector3.Lerp(startPos, groundedPos, Time.deltaTime * 4);
            //}
        }
        */
        
    }

    public bool GetGrab()
    {
        return triggerAction.GetState(handType);
    }

    /*
    public void OnTriggerStay(Collider col)
    {
        Debug.Log("Trigger Enter: " + col.gameObject.name);
        if (col.tag == "RightHand" || col.tag == "LeftHand") // Wand
        {
            if (triggerAction.GetStateDown(handType))
            {
                InteractWithFlyingObjects();
            }
        }
    }
    */

    public void InteractWithFlyingObjects()
    {
        //code to let Objects fly
        //Debug.Log("Fly little Bee...fly");
        if (script.isCarrying == false)
        {
            //if (gameObject.transform.position.y > 0.1f)
            //{
            Vector3 startPos = gameObject.transform.position;
            Vector3 groundedPos = new Vector3(gameObject.transform.position.x, 0.01f, gameObject.transform.position.z);

            gameObject.transform.position = Vector3.Lerp(startPos, groundedPos, Time.deltaTime * 4);
            //}
        }
    }

}
