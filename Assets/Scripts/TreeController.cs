using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Valve.VR;

public class TreeController : MonoBehaviour
{
    public GameObject tree;
    public GameObject ast1;
    public GameObject ast2;
    public GameObject baumkrone;
    private Animator anim;
    private AudioSource treeAudio;

    public Material[] materials; //material colors in a set sized array
    public Renderer rend_ast1; //defines which object is getting rendered
    public Renderer rend_ast2; //defines which object is getting rendered
    public Renderer rend_baumkrone; //defines which object is getting rendered

    private int index = 1; //initialize at 1, otherwise you have to press twice to change color at first

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    // Start is called before the first frame update
    void Start()
    {
        //ast1 = gameObject.GetComponent<GameObject>();
        rend_ast1.enabled = true; //makes the rendered 3D-Object visable if enabled
        rend_ast2.enabled = true;
        rend_baumkrone.enabled = true;
        anim = GetComponent<Animator>();
        treeAudio = GetComponent<AudioSource>();
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
                InteractWithTree();
            }
        }
    }

    private void OnMouseDown()
    {
        index += 1; //when mouse is pressed down, increment up to the next index location
        if (index == materials.Length + 1) //when it reaces the end of the materials it starts over
        {
            index = 1;
        }
        //print(index);

        rend_ast1.sharedMaterial = materials[index - 1]; //this sets the material color values inside the index
        rend_ast2.sharedMaterial = materials[index - 1];
        rend_baumkrone.sharedMaterial = materials[index - 1];

        //Animation abspielen von Baumkrone
        anim.SetTrigger("Active");
        anim.Play("zoom");
        treeAudio.Play();
    }

    public void InteractWithTree()
    {
        index += 1; //when mouse is pressed down, increment up to the next index location
        if (index == materials.Length + 1) //when it reaces the end of the materials it starts over
        {
            index = 1;
        }
        
        rend_ast1.sharedMaterial = materials[index - 1]; //this sets the material color values inside the index
        rend_ast2.sharedMaterial = materials[index - 1];
        rend_baumkrone.sharedMaterial = materials[index - 1];

        //Animation abspielen von Baumkrone
        anim.SetTrigger("Active");
        anim.Play("zoom");
        treeAudio.Play();
    }

}
