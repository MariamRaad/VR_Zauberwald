using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class XylophoneController : MonoBehaviour
{
    private AudioSource xylAudio;
    private Animator animFlower;

    private GameObject note1;
    private GameObject note2;
    private GameObject note3;
    private Animator animNote1;
    private Animator animNote2;
    private Animator animNote3;

    // Start is called before the first frame update
    void Start()
    {
        xylAudio = GetComponent<AudioSource>();
        animFlower = GetComponent<Animator>();
        note1 = GameObject.Find("quarter_note");
        animNote1 = note1.GetComponent<Animator>();
        note2 = GameObject.Find("sixteenth_note");
        animNote2 = note2.GetComponent<Animator>();
        note3 = GameObject.Find("eighth_note");
        animNote3 = note3.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger Enter: " + col.gameObject.name);
        if (col.tag == "RightHand" || col.tag == "LeftHand") // Wand
        {
            PlayXylophone();
        }

    }
    private void OnMouseDown()
    {
        xylAudio.Play();//Animation abspielen
        animFlower.SetTrigger("Active");

        if (gameObject.name == "Flower_Xylophone_1")
        {
            animFlower.Play("flower1");
            animNote1.SetTrigger("Active");
            animNote1.Play("theNote_viewer 1");
        }
        else if (gameObject.name == "Flower_Xylophone_2")
        {
            animFlower.Play("flower2");
            animNote2.SetTrigger("Active");
            animNote2.Play("theNote_viewer 2");
        }
        else if (gameObject.name == "Flower_Xylophone_3")
        {
            animFlower.Play("flower3");
            animNote3.SetTrigger("Active");
            animNote3.Play("theNote_viewer");
        }
    }

    private void PlayXylophone()
    {
        xylAudio.Play();//Animation abspielen
        animFlower.SetTrigger("Active");

        if (gameObject.name == "Flower_Xylophone_1")
        {
            animFlower.Play("flower1");
            animNote1.SetTrigger("Active");
            animNote1.Play("theNote_viewer 1");
        }
        else if (gameObject.name == "Flower_Xylophone_2")
        {
            animFlower.Play("flower2");
            animNote2.SetTrigger("Active");
            animNote2.Play("theNote_viewer 2");
        }
        else if (gameObject.name == "Flower_Xylophone_3")
        {
            animFlower.Play("flower3");
            animNote3.SetTrigger("Active");
            animNote3.Play("theNote_viewer");
        }
    }
}
