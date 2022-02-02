using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSwitch : MonoBehaviour
{
    
    public GameObject door, doorsound;
    public float speed =5f;

    public bool isElectrified, isElectrified1, is1;

    public GameObject red, green;

    void Start()
    {
        doorsound.SetActive(false); 
        green.SetActive(false);
        red.SetActive(true);
    }


    void OnTriggerEnter(Collider trig)
    {
        
        if (trig.CompareTag("electricity") && !is1)
        {
            isElectrified = true;
         

        }

        if (trig.CompareTag("electricity") && is1)
        {
            isElectrified1 = true;


        }
    }


   

    // Update is called once per frame
    void Update()
    {
        
        if (isElectrified)
        {

            door.transform.position = Vector3.MoveTowards(door.transform.position, new Vector3 (door.transform.position.x, door.transform.position.y -10, door.transform.position.z), speed* Time.deltaTime);
            red.SetActive(false);
            green.SetActive(true);
            doorsound.SetActive(true);


            Destroy(door.gameObject, 2);

        }

        if (isElectrified1)
        {

            door.transform.position = Vector3.MoveTowards(door.transform.position, new Vector3(door.transform.position.x, -3.26f, door.transform.position.z), speed * Time.deltaTime);
            red.SetActive(false);
            green.SetActive(true);
            doorsound.SetActive(true);




        }
    }
}
