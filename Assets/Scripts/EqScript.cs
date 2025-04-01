using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqScript : MonoBehaviour
{
    public float EqDamage = 10f;
    public GameObject gameManager;
    TimerScript timer;
    
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        timer = gameManager.GetComponent<TimerScript>();
    }
    

    private void OnCollisionStay(Collision collision)
    {
        if (timer.EqStatus == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                print(collision.gameObject + " Earthquake");
                timer.oxygenLevel = timer.oxygenLevel - EqDamage * Time.deltaTime;
            }
        }
        if (timer.EqStatus == false)
        {

        }
    }
}
