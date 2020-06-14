using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrelCanCompositeController : MonoBehaviour
{
    //public GameObject[] barrelSetGroup;
    public int currentLevel;
    public GameObject[] allLevels;

    private GameObject set_1;
    private GameObject set_2;
    private GameObject set_3;

    private GameObject barrel_1;
    private Vector3 coordinates_1;
    private Vector3 rotation_1;
    private GameObject barrel_2;
    private Vector3 coordinates_2;
    private Vector3 rotation_2;
    private GameObject barrel_3;
    private Vector3 coordinates_3;
    private Vector3 rotation_3;
    private GameObject barrel_4;
    private Vector3 coordinates_4;
    private Vector3 rotation_4;
    private GameObject barrel_5;
    private Vector3 coordinates_5;
    private Vector3 rotation_5;
    private GameObject barrel_6;
    private Vector3 coordinates_6;
    private Vector3 rotation_6;
    private GameObject barrel_7;
    private Vector3 coordinates_7;
    private Vector3 rotation_7;
    private GameObject barrel_8;
    private Vector3 coordinates_8;
    private Vector3 rotation_8;
    private GameObject barrel_9;
    private Vector3 coordinates_9;
    private Vector3 rotation_9;
    private GameObject barrel_10;
    private Vector3 coordinates_10;
    private Vector3 rotation_10;
    private GameObject barrel_11;
    private Vector3 coordinates_11;
    private Vector3 rotation_11;
    private GameObject barrel_12;
    private Vector3 coordinates_12;
    private Vector3 rotation_12;

    private GameObject textObj;
    public int points;
    private TextMeshProUGUI scoreText;
    private bool levelHasChanged = false;

    private AudioSource aux;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;

        set_1 = GameObject.Find("Set_1");
        set_2 = GameObject.Find("Set_2");
        set_3 = GameObject.Find("Set_3");


        barrel_1 = GameObject.Find("Barrel_1");
        coordinates_1 = new Vector3(-18.988f, 0.675f, -24.87f);
        rotation_1 = new Vector3(0, -66.562f, 0);

        barrel_2 = GameObject.Find("Barrel_2");
        coordinates_2 = new Vector3(-18.834f, 0.675f, -24.535f);
        rotation_2 = new Vector3(0, -32.465f, 0);

        barrel_3 = GameObject.Find("Barrel_3");
        coordinates_3 = new Vector3(-18.685f, 0.675f, -24.147f);
        rotation_3 = new Vector3(0, -66.562f, 0);

        barrel_4 = GameObject.Find("Barrel_4");
        coordinates_4 = new Vector3(-18.918f, 0.675f, -24.7f);
        rotation_4 = new Vector3(0, -66.562f, 0);

        barrel_5 = GameObject.Find("Barrel_5");
        coordinates_5 = new Vector3(-18.773f, 0.675f, -24.371f);
        rotation_5 = new Vector3(0, -66.562f, 0);

        barrel_6 = GameObject.Find("Barrel_6");
        coordinates_6 = new Vector3(-18.839f, 1f, -24.6f);
        rotation_6 = new Vector3(0, -66.562f, 0);
        
        barrel_7 = GameObject.Find("Barrel_7");
        coordinates_7 = new Vector3(-18.988f, 0.675f, -24.870f);
        rotation_7 = new Vector3(0, -66.562f, 0);

        barrel_8 = GameObject.Find("Barrel_8");
        coordinates_8 = new Vector3(-18.834f, 0.675f, -24.480f);
        rotation_8 = new Vector3(0, -66.562f, 0);

        barrel_9 = GameObject.Find("Barrel_9");
        coordinates_9 = new Vector3(-18.685f, 0.675f, -24.080f);
        rotation_9 = new Vector3(0, -66.562f, 0);
        
        barrel_10 = GameObject.Find("Barrel_10");
        coordinates_10 = new Vector3(-18.925f, 1f, -24.670f);
        rotation_10 = new Vector3(0, -66.562f, 0);
        
        barrel_11 = GameObject.Find("Barrel_11");
        coordinates_11 = new Vector3(-18.783f, 1f, -24.270f);
        rotation_11 = new Vector3(0, -66.562f, 0);
        
        barrel_12 = GameObject.Find("Barrel_12");
        coordinates_12 = new Vector3(-18.847f, 1.3f, -24.490f);
        rotation_12 = new Vector3(0, -66.562f, 0);
        
        set_1.SetActive(true);
        set_2.SetActive(false);
        set_3.SetActive(false);

        textObj = GameObject.Find("Score");
        scoreText = textObj.GetComponent<TextMeshProUGUI>();
        scoreText.text = points.ToString();

        aux = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GroundFallenCheck()
    {
        if (AllGrounded())
        {
            //First deactivate all the Barrels on the ground
            //Set the bool hasFallen to false for each barrel  
            //GameObject[] currentSet = GameObject.FindGameObjectsWithTag("Barrel");

            /*
            Transform currentSet = allLevels[currentLevel].transform;

            foreach (Transform barrelObj in currentSet)
            {
                if (barrelObj.GetComponent<BarrelController>().hasFallen == true)
                {
                    //Destroy(barrelObj, 2);
                    //barrelObj.SetActive(false);
                    barrelObj.GetComponent<BarrelController>().hasFallen = false;

                    /*
                    if (currentLevel == 0)
                    {
                        GameObject barrel_3 = GameObject.Find("Barrel_3");
                        barrel_3.GetComponent<BarrelController>().hasFallen = false;
                    }
                }
            }
            */

            //load the next Set of Barrels
            //Debug.Log("Load next level");
            LoadNextLevel();
            //StartCoroutine(Wait());
            //LoadSameLevel();
        }
    }

    public bool AllGrounded()
    {
        /*
        Transform currentSet = allLevels[currentLevel].transform;

        foreach (Transform t in currentSet)
        {
            if (t.GetComponent<BarrelController>().hasFallen == false)
            {
                return false;
            }
        }
        return true;
        */

        if (currentLevel == 0)
        {
            set_1.SetActive(true);
            set_2.SetActive(false);
            set_3.SetActive(false);

            //Debug.Log("barrel_1 " + barrel_1.gameObject.GetComponent<BarrelController>().hasFallen);
            //Debug.Log("barrel_2 " + barrel_2.gameObject.GetComponent<BarrelController>().hasFallen);
            //Debug.Log("barrel_3 " + barrel_3.gameObject.GetComponent<BarrelController>().hasFallen);

            if ((barrel_1.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_2.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_3.gameObject.GetComponent<BarrelController>().hasFallen == true))
            {
                return true;
            }
        }
        else if (currentLevel == 1)
        {
            set_2.SetActive(true);
            set_1.SetActive(false);
            set_3.SetActive(false);

            if ((barrel_4.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_5.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_6.gameObject.GetComponent<BarrelController>().hasFallen == true))
            {
                return true;
            }
        }
        else if (currentLevel == 2)
        {
            set_3.SetActive(true);
            set_1.SetActive(false);
            set_2.SetActive(false);

            if ((barrel_7.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_8.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_9.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_10.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_11.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_12.gameObject.GetComponent<BarrelController>().hasFallen == true))
            {
                return true;
            }
        }

        return false;
    }

    public void LoadNextLevel()
    {
        //disable current Level
        //allLevels[currentLevel].SetActive(false);

        currentLevel++;

        //defined for being able to start over with the levels
        if (currentLevel >= 3) currentLevel = 0; //allLevels.Length

        //enable next level
        //allLevels[currentLevel].SetActive(true);

        //Debug.Log("currentLevel " + currentLevel);
        if (currentLevel == 0)
        {
            //if ((barrel_1.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_2.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_3.gameObject.GetComponent<BarrelController>().hasFallen == true))
            //{
                barrel_1.gameObject.GetComponent<BarrelController>().hasFallen = false;
                barrel_2.gameObject.GetComponent<BarrelController>().hasFallen = false;
                barrel_3.gameObject.GetComponent<BarrelController>().hasFallen = false;


                set_1.SetActive(true);
                set_2.SetActive(false);
                set_3.SetActive(false);

                barrel_1.SetActive(true);
                barrel_2.SetActive(true);
                barrel_3.SetActive(true);

                barrel_1.transform.position = coordinates_1;
                barrel_1.transform.rotation = Quaternion.Euler(rotation_1);
                barrel_1.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_1.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

                barrel_2.transform.position = coordinates_2;
                barrel_2.transform.rotation = Quaternion.Euler(rotation_2);
                barrel_2.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_2.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

                barrel_3.transform.position = coordinates_3;
                barrel_3.transform.rotation = Quaternion.Euler(rotation_3);
                barrel_3.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_3.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            //}
        }
        else if (currentLevel == 1)
        {
            //if ((barrel_4.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_5.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_6.gameObject.GetComponent<BarrelController>().hasFallen == true))
            //{
                barrel_4.gameObject.GetComponent<BarrelController>().hasFallen = false;
                barrel_5.gameObject.GetComponent<BarrelController>().hasFallen = false;
                barrel_6.gameObject.GetComponent<BarrelController>().hasFallen = false;

                set_2.SetActive(true);
                set_1.SetActive(false);
                set_3.SetActive(false);

                barrel_4.SetActive(true);
                barrel_5.SetActive(true);
                barrel_6.SetActive(true);

                barrel_4.transform.position = coordinates_4;
                barrel_4.transform.rotation = Quaternion.Euler(rotation_4);
                barrel_4.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_4.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

                barrel_5.transform.position = coordinates_2;
                barrel_5.transform.rotation = Quaternion.Euler(rotation_2);
                barrel_5.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_5.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

                barrel_6.transform.position = coordinates_6;
                barrel_6.transform.rotation = Quaternion.Euler(rotation_6);
                barrel_6.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_6.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            //}
        }
        else if (currentLevel == 2)
        {
            //if ((barrel_4.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_5.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_6.gameObject.GetComponent<BarrelController>().hasFallen == true))
            //{
            barrel_7.gameObject.GetComponent<BarrelController>().hasFallen = false;
            barrel_8.gameObject.GetComponent<BarrelController>().hasFallen = false;
            barrel_9.gameObject.GetComponent<BarrelController>().hasFallen = false;
            
            barrel_10.gameObject.GetComponent<BarrelController>().hasFallen = false;
            barrel_11.gameObject.GetComponent<BarrelController>().hasFallen = false;
            barrel_12.gameObject.GetComponent<BarrelController>().hasFallen = false;
            

            set_3.SetActive(true);
            set_1.SetActive(false);
            set_2.SetActive(false);

            barrel_7.SetActive(true);
            barrel_8.SetActive(true);
            barrel_9.SetActive(true);
           
            barrel_10.SetActive(true);
            barrel_11.SetActive(true);
            barrel_12.SetActive(true);
             

            barrel_7.transform.position = coordinates_7;
            barrel_7.transform.rotation = Quaternion.Euler(rotation_7);
            barrel_7.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            barrel_7.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            barrel_8.transform.position = coordinates_8;
            barrel_8.transform.rotation = Quaternion.Euler(rotation_8);
            barrel_8.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            barrel_8.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            barrel_9.transform.position = coordinates_9;
            barrel_9.transform.rotation = Quaternion.Euler(rotation_9);
            barrel_9.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            barrel_9.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

            
            barrel_10.transform.position = coordinates_10;
            barrel_10.transform.rotation = Quaternion.Euler(rotation_10);
            barrel_10.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            barrel_10.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            
            barrel_11.transform.position = coordinates_11;
            barrel_11.transform.rotation = Quaternion.Euler(rotation_11);
            barrel_11.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            barrel_11.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            
            barrel_12.transform.position = coordinates_12;
            barrel_12.transform.rotation = Quaternion.Euler(rotation_12);
            barrel_12.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            barrel_12.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            
            //}
        }

        levelHasChanged = true;


        /*
        //Reactivate the Barrels from before
        GameObject[] currentSet = GameObject.FindGameObjectsWithTag("Barrel");

        foreach (GameObject barrelObj in currentSet)
        {
            if (barrelObj.GetComponent<BarrelController>().hasFallen == true)
            {
                //hasFallen = false;
                //barrelObj.GetComponent<BarrelController>().hasFallen = false;
                //Destroy(barrelObj, 2);
                barrelObj.SetActive(true);
            }
        }*/

    }

    public void LoadSameLevel()
    {
        //allLevels[currentLevel].SetActive(false);
        currentLevel = 0;
        //allLevels[currentLevel].SetActive(true);

        if (currentLevel == 0)
        {
            if ((barrel_1.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_2.gameObject.GetComponent<BarrelController>().hasFallen == true) & (barrel_3.gameObject.GetComponent<BarrelController>().hasFallen == true))
            {
                barrel_1.gameObject.GetComponent<BarrelController>().hasFallen = false;
                barrel_2.gameObject.GetComponent<BarrelController>().hasFallen = false;
                barrel_3.gameObject.GetComponent<BarrelController>().hasFallen = false;

                barrel_1.transform.position = coordinates_1;
                barrel_1.transform.rotation = Quaternion.Euler(rotation_1);
                barrel_1.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_1.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

                barrel_2.transform.position = coordinates_2;
                barrel_2.transform.rotation = Quaternion.Euler(rotation_2);
                barrel_2.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_2.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

                barrel_3.transform.position = coordinates_3;
                barrel_3.transform.rotation = Quaternion.Euler(rotation_3);
                barrel_3.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                barrel_3.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            }
        }

        levelHasChanged = true;
    }


    public void UpdateScore()
    {
        
        if (levelHasChanged)
        {
            /*
            points = 0;
            Debug.Log("POINTS " + points);
            scoreText.text = points.ToString();
            */

            aux.Play();
        }
        
        
        points = points + 1;
        //Debug.Log("POINTS " + points);
        scoreText.text = points.ToString();

        levelHasChanged = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(12);
    }
}
