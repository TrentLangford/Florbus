using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour
{
    public GameObject florbus;
    Player player;

    void Awake()
    {
        florbus = GameObject.Find("Florbus");
        player = florbus.GetComponent<Player>();
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
            player.jumpSeconds = player.jumpSeconds +2f;

            Destroy(this.gameObject);
        }
    }
}
