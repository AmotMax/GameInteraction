using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto : MonoBehaviour
{
    public GameObject tuto1, tuto2, tuto3;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tuto1")
        {
            tuto1.SetActive(true);
           
        }

        if (other.gameObject.tag == "tuto2")
        {
            tuto2.SetActive(true);

        }

        if (other.gameObject.tag == "tuto3")
        {
            tuto3.SetActive(true);

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "tuto1")
        {
            tuto1.SetActive(true);

        }

        if (other.gameObject.tag == "tuto2")
        {
            tuto2.SetActive(true);

        }

        if (other.gameObject.tag == "tuto3")
        {
            tuto3.SetActive(true);

        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "tuto1" || other.gameObject.tag == "tuto2" || other.gameObject.tag == "tuto3")
        {      
            tuto1.SetActive(false);
            tuto2.SetActive(false);
            tuto3.SetActive(false);
        }
    }
}
