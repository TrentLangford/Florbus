using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleScript : MonoBehaviour
{
    public GameObject gameManager;
    TimerScript timer;
   
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        timer = gameManager.GetComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {


            print(other.gameObject + " enter");
            timer.oxygenLevel = timer.oxygenLevel - 20;
        }
    }
}
