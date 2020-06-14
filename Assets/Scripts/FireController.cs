using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FireController : MonoBehaviour
{
    public ParticleSystem fire;
    protected bool letPlay = true;
    private AudioSource aux;
    public new Light light;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    public AudioClip campfire;
    public AudioClip bigFire;

    // Start is called before the first frame update
    void Start()
    {
        fire = GameObject.FindGameObjectWithTag("Fire2").GetComponent<ParticleSystem>();
        fire.Stop();
        aux = GetComponent<AudioSource>();
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
        if (col.tag == "RightHand" || col.tag == "LeftHand") //Wand
        {
            if (triggerAction.GetLastStateDown(handType))
            {
                InteractWithFire();
            }
        }
    }


    public void InteractWithFire()
    {
        if (letPlay)
        {
            if (!fire.isPlaying)
            {
                //Debug.Log("Play");
                fire.Play();
                aux.clip = bigFire;
                //aux.loop = true;
                aux.Play();
                light.range = 3.2f;
                letPlay = !letPlay;
            }
        }
        else
        {
            if (fire.isPlaying)
            {
                //Debug.Log("Stop");
                fire.Stop();
                aux.clip = campfire;
                aux.Play();
                //aux.Stop();
                light.range = 1.4f;
                letPlay = !letPlay;
            }
        }
    }

    private void OnMouseDown()
    {
        if (letPlay)
        {
            if (!fire.isPlaying)
            {
                //Debug.Log("Play");
                fire.Play();
                aux.clip = bigFire;
                //aux.loop = true;
                aux.Play();
                light.range = 3.2f;
                letPlay = !letPlay;
            }
        }
        else
        {
            if (fire.isPlaying)
            {
                //Debug.Log("Stop");
                fire.Stop();
                aux.clip = campfire;
                aux.Play();
                //aux.Stop();
                light.range = 1.4f;
                letPlay = !letPlay;
            }
        }
    }
}
