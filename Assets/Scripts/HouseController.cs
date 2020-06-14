using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HouseController : MonoBehaviour
{
    private ParticleSystem smoke;
    private Animator anim;
    private AudioSource aux;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        aux = GetComponent<AudioSource>();
        smoke = GameObject.FindGameObjectWithTag("Smoke").GetComponent<ParticleSystem>();
        smoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                InteractWithHouse();
            }
        }
    }
    
    private void OnMouseDown()
    {
        if (!smoke.isPlaying)
        {
            smoke.Play();
            //Debug.Log("Play");
            //Audio
            aux.Play();
            //Animation abspielen
            anim.SetTrigger("Active");
            anim.Play("house");
        }
        else
        {
            if (smoke.isPlaying)
            {
                smoke.Stop();
                //Debug.Log("Stop");
            }
        }
    }

    public void InteractWithHouse()
    {
        if (!smoke.isPlaying)
        {
            smoke.Play();
            //Debug.Log("Play");
            //Audio
            aux.Play();
            //Animation abspielen
            anim.SetTrigger("Active");
            anim.Play("house");
        }
        else
        {
            if (smoke.isPlaying)
            {
                smoke.Stop();
                //Debug.Log("Stop");
            }
        }
    }

}
