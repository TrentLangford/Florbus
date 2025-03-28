using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Script : MonoBehaviour
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

            if (timer.oxygenLevel < 200)
            {
                timer.oxygenLevel = timer.oxygenLevel + 20;
            }

            Destroy(this.gameObject);
        }
    }
}
