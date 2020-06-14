using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumController : MonoBehaviour
{
    private AudioSource drumAudio;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        drumAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Trigger Enter: " + col.gameObject.name);
        if (col.tag == "RightHand" || col.tag == "LeftHand") //Wand
        {
            PlayDrums();
        }
    }

    private void OnMouseDown()
    {
        drumAudio.Play();
        //Animation abspielen
        anim.SetTrigger("Active");
        if (gameObject.name == "Mushroom_Drum_HiHat")
        {
            anim.Play("drums_hihat");
        }
        else if (gameObject.name == "Mushroom_Drum_Snare")
        {
            anim.Play("drums_snare");
        }
        else if (gameObject.name == "Mushroom_Drum_Tom")
        {
            anim.Play("drums_tom");
        }
        else if (gameObject.name == "Mushroom_Drum_Crash")
        {
            anim.Play("drums_crash");
        }

    }

    private void PlayDrums()
    {
        drumAudio.Play();
        //Animation abspielen
        anim.SetTrigger("Active");
        if (gameObject.name == "Mushroom_Drum_HiHat")
        {
            anim.Play("drums_hihat");
        }
        else if (gameObject.name == "Mushroom_Drum_Snare")
        {
            anim.Play("drums_snare");
        }
        else if (gameObject.name == "Mushroom_Drum_Tom")
        {
            anim.Play("drums_tom");
        }
        else if (gameObject.name == "Mushroom_Drum_Crash")
        {
            anim.Play("drums_crash");
        }
    }
}
