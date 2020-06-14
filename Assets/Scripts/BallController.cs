using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 spawnPos;
    private Vector3 spawnRot;

    public HandController handScript;

    // Start is called before the first frame update
    void Start()
    {
        //spawnPos = new Vector3(9.2f, 0.3f, -7.3f);
        spawnPos = new Vector3(-16.5f, 1f, -26.1f); //(-16.621f, 0.788f, -26.057f);
        //spawnPos = new Vector3(-16.537f, 1f, -25.894f);
        spawnRot = new Vector3(-8.101001f, 156.562f, 146.757f);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider col) // not OnCollisionEnter (Collision col)
    {
        /* 
         * Plane in Editor has to be underneath the teleport area, and plane area
         * because otherwise Ball or Barrels are stuck between them and the Collision get triggered all the time
         * which led to infinite spawning of balls, when player is teleporting or holding the trackpad-button
         */
        if (col.gameObject.name == "Plane") //CompareTag("BallCollider")
        {
            //Debug.Log("Ball hit ground");
            /* following code had the problem that the ball was placed at the right location but with the moving-Vector of the throw before
             * so it would still roll even if it should spawn at this specific location/rotation
             */
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = spawnPos;
            this.gameObject.transform.rotation = Quaternion.Euler(spawnRot);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            //Debug.Log(gameObject.transform.position);
            this.gameObject.SetActive(true);

            /*
            //if (handScript.activatedScoreSystem)
            //{
                GameObject newBall = Instantiate(gameObject, spawnPos, transform.rotation);
                Destroy(this.gameObject, 1.5f);
            //}
            */
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //to avoid that the Ball might stay on the bench and then collide with the barrels as they spawn
        if (collision.gameObject.name == "Bench")
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = spawnPos;
            this.gameObject.transform.rotation = Quaternion.Euler(spawnRot);
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            //Debug.Log(gameObject.transform.position);
            this.gameObject.SetActive(true);
        }
    }

}
