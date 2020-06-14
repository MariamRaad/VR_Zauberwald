using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrelController : MonoBehaviour
{
    //private GameObject textObj;
    //private TextMeshProUGUI scoreText;
    //public int points;

    public HandController handScript;
    private BarrelCanCompositeController compositeScript;

    public bool hasFallen;

    private AudioSource aux;
    public AudioClip hitWood;
    public AudioClip collectPoints;

    // Start is called before the first frame update
    void Start()
    {
        //textObj = GameObject.Find("Score");
        //scoreText = textObj.GetComponent<TextMeshProUGUI>();
        //points = 0;
        //scoreText.text = points.ToString();

        //hasFallen = false;

        compositeScript = GameObject.Find("Barrels").GetComponent<BarrelCanCompositeController>();

        aux = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        // Player has to be at specific Teleportpoint or area
        //Debug.Log("aktiviertes SYSTEM " + handScript.activatedScoreSystem);
        //if (handScript.activatedScoreSystem)
        //{
            //Debug.Log("aktiviertes SYSTEM " + handScript.activatedScoreSystem);


            //Barrels have to hit the ground
            if (col.gameObject.name == "Plane") //BarrelCollider
            {
                hasFallen = true;
                //Debug.Log(gameObject.name + " has fallen");
                compositeScript.GroundFallenCheck(); //BarrelCanCompositeController.instance.GroundFallenCheck();


                //Audio abspielen, Punkte richtig zählen
                //Debug.Log("Barrel hit the collider -> Player should get some points");
                aux.clip = collectPoints;
                aux.Play();
                compositeScript.UpdateScore();


            }
        //}
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            //Debug.Log("Barrel was hit by the ball");
            aux.clip = hitWood;
            aux.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Do nothing
    }

}
