using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RoosterController : MonoBehaviour
{
    private Animator anim;
    private AudioSource aux;

    //private GameObject chickenScript;
    public MoveChicken chickenScript;
    private bool chickenRun = false;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    private int index = 1;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        aux = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if Player interacted with the House
        if (chickenRun)
        {
            //Debug.Log("RUN CHICKEN...RUN!");

            if (index % 2 == 0)
            {
                //Debug.Log("ZIEL 1");
                target = new Vector3(39, 0, 12);
}
            else if (index % 1 == 0)
            {
                //Debug.Log("ZIEL 2");
                target = new Vector3(39, 0, 22);
            }

            chickenScript.moveChicken(target);

            if (chickenScript.isAtTarget)
            {
                chickenRun = false;
            }
        }
    }
    
    public bool GetGrab()
    {
        return triggerAction.GetState(handType);
    }

    public void OnTriggerStay(Collider col)
    {
        Debug.Log("Trigger Enter: " + col.gameObject.name);
        if (col.tag == "RightHand" || col.tag == "LeftHand") // Wand
        {
            if (triggerAction.GetLastStateDown(handType))
            {
                InteractWithRooster();
            }
        }
    }

    private void OnMouseDown()
    {
        // Audio
        aux.Play();
        // Animation abspielen
        anim.SetTrigger("Active");
        anim.Play("rooster");
        chickenRun = true;

        index++;
    }

    public void InteractWithRooster()
    {
        // Audio
        aux.Play();
        // Animation abspielen
        anim.SetTrigger("Active");
        anim.Play("rooster");
        chickenRun = true;

        index++;
    } 
}
