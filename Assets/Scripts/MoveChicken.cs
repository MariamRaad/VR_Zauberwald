using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveChicken : MonoBehaviour
{
    private GameObject chicken;
    private Animator chickenAnim;

    public Transform[] target;
    public float speed;
    private int current;

    public bool isAtTarget;

    private Vector3 target0 = new Vector3(39, 0, 12);
    private Vector3 target1 = new Vector3(39, 0, 22);

    public NavMeshAgent chickenAgent;

    // Start is called before the first frame update
    void Start()
    {
        chicken = GameObject.Find("Chicken");
        chickenAnim = chicken.GetComponent<Animator>();

        isAtTarget = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveChicken(Vector3 dest)
    {
        //Debug.Log("Chicken is activated");
        chickenAnim.enabled = true; // to toggle it
        chickenAnim.SetTrigger("Active");
        chickenAnim.Play("Chicken");

        chickenAgent.SetDestination(dest); // Chicken moves to the given destination

        // if it is near enough
        if (Vector3.Distance(chickenAgent.transform.position, dest) < 1f)
        {
            isAtTarget = true;
            chickenAnim.enabled = false; // stop the animation
        }





   
        // Vector Berechnungen gingen nicht, da sie zu ungenau waren beim Vergleichen -> float!

        /*
        if (transform.position != target0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target0, 4f * Time.deltaTime);

            //if (Vector3.Distance(transform.position, target0) < 0.1f) // == or Equals didn't work
            if (transform.position == target0)
            {
                Debug.Log("Chicken is at Target 0");
                isAtTarget_0 = true;

                // Animation Stop
                chickenAnim.enabled = false;
            }
        }
        else if (transform.position != target1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1, 4f * Time.deltaTime);

            if (Vector3.Distance(transform.position, target1) < 0.1f) // == or Equals didn't work
            {
                Debug.Log("Chicken is at Target 1");
                isAtTarget_1 = true;

                // Animation Stop
                chickenAnim.enabled = false;
            }
        }
        */

        /*
        // If chicken is at target 1 (or any other position), go back to target 0
        if (Vector3.Distance(transform.position, target[0].position) > 1f) //transform.position != target[0].position //transform.position != target[current].position
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[0].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

            //Debug.Log("Chicken Pos " + transform.position);
            //Debug.Log("Distanz " + Vector3.Distance(pos, target[0].position));

            if (Vector3.Distance(pos, target[0].position) < 1f) // == or Equals() didn't work
            //if ()
            {
                Debug.Log("Chicken is at Target 0");
                isAtTarget_0 = true;

                // Animation Stop
                chickenAnim.enabled = false;

                // Bewegung stoppen
            }


        }
        // If chicken is at target 0, go back to target 1
        else if (Vector3.Distance(transform.position, target[1].position) > 1f) //transform.position != target[1].position
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[1].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

            Debug.Log("Chicken Pos " + transform.position);
            Debug.Log("Distanz " + Vector3.Distance(pos, target[1].position));

            if (Vector3.Distance(pos, target[1].position) < 1f) // == or Equals() didn't work
            {
                //Debug.Log("Chicken Pos " + transform.position);
                Debug.Log("Chicken is at Target 1");
                isAtTarget_1 = true;

                // Animation Stop
                chickenAnim.enabled = false;
            }
           
        
        }
        */

    }

    /* 
     if (transform.position != target[current].position)
     {
        Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(pos);
     }
     else current = (current + 1) % target.Length;
     */




}
