using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqScript : MonoBehaviour
{
    public int EqDamage = 10;
    public GameObject gameManager;
    TimerScript timer;
    // Start is called before the first frame update
    
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        timer = gameManager.GetComponent<TimerScript>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (timer.EqStatus == true)
        {


            if (collision.gameObject.tag == "Player")
            {


                print(collision.gameObject + " Earthquake");
                timer.oxygenLevel = timer.oxygenLevel - 1;
            }
        }
        if (timer.EqStatus == false)
        {

        }
    }
}
