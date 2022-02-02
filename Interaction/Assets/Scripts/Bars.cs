using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bars : MonoBehaviour
{
    public Image energy;
    public float time;
    
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = player.GetComponent<PlayerController>().timer;
        energy.fillAmount = time / 3;
    }
}
