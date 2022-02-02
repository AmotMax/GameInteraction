using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; 
    public float jumpForce;
    public float speed;
    public float direction = 0;
    public float crabdirection = 0;
    public float rotatespeed;

    public GameObject camera1, camera2, camera3;
    
    public bool isFPS;
    public RaycastHit hit;
    public GameObject cursorFPS;

    public Transform firepoint;
    public GameObject bullet;
 
    public GameObject electriccharge, reloader, end;

    public float range = 100f;
    
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float timer;
    public bool timerRising;

    public bool isPaused;
    public GameObject pauseMenuUI;

    public GameObject shootsound, chargesound, deathsound, victorysound;
    public GameObject deathparticle;


    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);

        cursorFPS.SetActive(false);

        isFPS = false;
        electriccharge.SetActive(false);
        chargesound.SetActive(false);

        Cursor.visible = false;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;



    }

    // Update is called once per frame
    void Update()
    {
        camera3.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
                Cursor.visible = false;
            }
            else 
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
                Cursor.visible = true;
            }

        }


        Move();
        ElectricBox();
        Gun();

        if (Input.GetMouseButton(1) && !isPaused)
        {
            camera2.SetActive(true);
            cursorFPS.SetActive(true);

            camera1.SetActive(false);
            isFPS = true;
            electriccharge.SetActive(false);

            speed = 12;
            jumpForce = 6;
            timerRising = true;
            electriccharge.SetActive(false);

            gameObject.GetComponent<TrailRenderer>().enabled = false;
        }

        if(Input.GetMouseButtonUp(1) && !isPaused)
        {
            camera2.SetActive(false);
            cursorFPS.SetActive(false);

            camera1.SetActive(true);
            isFPS = false;

            gameObject.GetComponent<TrailRenderer>().enabled = true;

        }

        


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb.velocity = Vector3.up * jumpForce;

        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);
    }

    void Move()
    {
        if(direction <= 0.1f)
        {
            direction =0;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            direction = 1;

        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            direction = 0;


        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = -1;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            direction = 0;
        }

        if (Input.GetKey(KeyCode.Q) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            crabdirection = -1;

        }
        else if (Input.GetKeyUp(KeyCode.Q) && !(Input.GetKeyDown(KeyCode.LeftShift)))
        {
            crabdirection = 0;
        }


        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            crabdirection = 1;
        }
        else if (Input.GetKeyUp(KeyCode.D) && !(Input.GetKeyDown(KeyCode.LeftShift)))
        {
            crabdirection = 0;
        }




        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.Q)))
        {
            transform.Rotate(0, -rotatespeed * Time.deltaTime, 0);

        }


        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D)))
        {
            transform.Rotate(0, rotatespeed * Time.deltaTime, 0);

        }





        Vector3 movement = transform.forward * speed * direction * Time.deltaTime;
        transform.position = transform.position + movement;

        Vector3 crabmovement = transform.right * speed * crabdirection * Time.deltaTime;
        transform.position = transform.position + crabmovement;
    }


    void Gun()
    {
        

        if (Input.GetMouseButtonUp(0) && isFPS && timer > 1 && !isPaused)
        {
            
            Instantiate(bullet, firepoint.transform.position, firepoint.rotation);
            Instantiate(shootsound, firepoint.transform.position, firepoint.rotation);

            timer -= 1;
           

        }
    }


    void ElectricBox()
    {
        

        if (Input.GetMouseButton(0) && !isFPS && timer >  0f && !isPaused)
        {
            speed = 3;
            jumpForce = 1;
            timer -= Time.deltaTime;
            timerRising = false;
            electriccharge.SetActive(true);
            chargesound.SetActive(true);

        }
        if (Input.GetMouseButtonUp(0) && !isFPS && !isPaused)
        {
            speed = 10;
            jumpForce = 6;
            timerRising = true;
            electriccharge.SetActive(false);
            chargesound.SetActive(false);


        }

        if (Input.GetMouseButton(0) && !isFPS && timer == 0f && !isPaused)
        {
            speed = 10;
            jumpForce = 6;
        }
         

        if(timer > 3f)
        {
            timer = 3f;
        }

        if (timer <= 0f && Input.GetMouseButton(0) && !isFPS && !isPaused)
        {
            timer = 0f;
            electriccharge.SetActive(false);
            chargesound.SetActive(false);


            Debug.Log("aj");
        }

        if (timerRising)
        {

            timer += Time.deltaTime;
        }

        

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "end")
        {

            Instantiate(end, firepoint.transform.position, firepoint.rotation);
            Destroy(gameObject);
            camera3.SetActive(true);
            Instantiate(victorysound, transform.position, transform.rotation);

        }

    }


    void OnCollisionEnter (Collision other)
        {
            if (other.gameObject.tag == "enemy")
            {

                Destroy(gameObject);
                Instantiate(reloader, firepoint.transform.position, firepoint.rotation);
                camera3.SetActive(true);
                Instantiate(deathparticle, transform.position, transform.rotation);
                Instantiate(deathsound, transform.position, transform.rotation);


            }


       

        if (other.gameObject.tag == "mur")
            {

               speed = 0.9f;

            }
        }

    void OnCollisionExit(Collision other)
    {
        

        if (other.gameObject.tag == "mur")
        {

            speed = 10f;

        }
    }


}
