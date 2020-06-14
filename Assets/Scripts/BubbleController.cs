using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BubbleController : MonoBehaviour
{
    public ParticleSystem bubbles;
    protected bool letPlay = true;
    private AudioSource aux;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    // Start is called before the first frame update
    void Start()
    {
        bubbles = GameObject.FindGameObjectWithTag("Bubbles").GetComponent<ParticleSystem>();
        bubbles.Stop();
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
                InteractWithBubbles();
            }
        }
    }

    private void OnMouseDown()
    {
        if (letPlay)
        {
            if (!bubbles.isPlaying)
            {
                bubbles.Play();
                aux.loop = true;
                aux.Play();
                Debug.Log("Play");
                letPlay = !letPlay;
            }
        }
        else
        {
            if (bubbles.isPlaying)
            {
                bubbles.Stop();
                aux.Stop();
                Debug.Log("Stop");
                letPlay = !letPlay;
            }
        }
        
    }

    public void InteractWithBubbles()
    {
        if (letPlay)
        {
            if (!bubbles.isPlaying)
            {
                bubbles.Play();
                aux.loop = true;
                aux.Play();
                Debug.Log("Play");
                letPlay = !letPlay;
            }
        }
        else
        {
            if (bubbles.isPlaying)
            {
                bubbles.Stop();
                aux.Stop();
                Debug.Log("Stop");
                letPlay = !letPlay;
            }
        }
    }
}
