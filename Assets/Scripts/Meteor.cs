using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject hitPosition;
    public float Velocity;
    Rigidbody body;
    Vector3 dir;

    public GameObject gameManager;
    TimerScript timer;

    private void Start()
    {
        body = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager");
        timer = gameManager.GetComponent<TimerScript>();
        
    }

    void Update()
    {
        dir = (hitPosition.transform.position - transform.position).normalized;
        body.velocity = dir * Velocity;

        //Debug.DrawRay(transform.position, dir, Color.white);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) timer.oxygenLevel = timer.oxygenLevel - 20;
        Destroy(this.gameObject);
        Destroy(hitPosition);
    }
}
