using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed=5f;
    public GameObject particle, sound, sound1;

    private PlayerController other;
    
    // Start is called before the first frame update
    void Start()
    {
        other = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.position = transform.position + movement;

        Destroy(gameObject, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mur") || other.CompareTag("enemy") || other.CompareTag("switch") )
        {
            
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(sound, transform.position, Quaternion.identity);


        }

        if (other.CompareTag("switch"))
        {
            Instantiate(sound1, transform.position, Quaternion.identity);
        }


    }
}
