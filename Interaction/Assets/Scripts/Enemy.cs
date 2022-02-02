using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 0f;
    public float newspeed = 1f;

   
    public float huntTimer;
    public bool isNear;
    public bool isHunting = false;

    public GameObject ok, bad;

    public float health =1;

    public GameObject death;


    // Start is called before the first frame update
    void Start()
    {
        bad.SetActive(false);
        ok.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.1f)
        {
            Destroy(gameObject);
            Instantiate(death, transform.position, Quaternion.identity);

        }


        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(isHunting)
        {
            bad.SetActive(true);
            ok.SetActive(false);
            transform.LookAt(target);

        }
        else
        {
            bad.SetActive(false);
            ok.SetActive(true);
        }



        if (isHunting == true && isNear == false)
        {
            huntTimer = huntTimer - Time.deltaTime;
        }

        if (huntTimer <= 0f)
        {
            speed = 0f;
            isHunting = false;
            huntTimer = 3f;
        }

        if (isNear)
        {
            huntTimer = 3f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            speed = newspeed;
            isHunting = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
        }

        if (other.CompareTag("electricity"))
        {
            health -= 0.2f;
            Destroy(other.gameObject);
        }



    }
}
