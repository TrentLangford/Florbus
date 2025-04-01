using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Planet movement
    public GameObject planetObject;
    private Planet planet;
    public float RotationSpeed = 5.0f;

    // Jump bounds
    public float JumpMaxHeight = 3f;
    Vector3 maxHeightVector;
    public float NormalHeight = -16f;
    public float Height;

    // Jumping/falling speeds
    public float JetpackSpeed = 3f;
    public float FallSpeed;

    public float DefaultJumpSeconds = 10f;
    public float jumpSeconds;
    [SerializeField] bool jetpacking = false;

    // Raycasting info
    public LayerMask raycastIgnore;
    public float snapPosDistance;
    Ray downRay;
    RaycastHit hitInfo;

    // Visuals
    public GameObject FlorbusModel;
    Vector2 lookVector;
    float lookAngle;
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("touching touching touching");
        /*if (collision.collider.CompareTag("Obstacle")) Debug.Log("owie owie owie");
        if (collision.collider.CompareTag("Planet"))
        {
            Debug.Log("touched base");
        }*/
    }
    Vector3 pos;
    void Start()
    {
        planet = planetObject.GetComponent<Planet>();
        // can be removed later
        if (FallSpeed == 0f) FallSpeed = JetpackSpeed * 2f;
        jumpSeconds = DefaultJumpSeconds;
        maxHeightVector = new Vector3(0f, 0f, NormalHeight - JumpMaxHeight);
        pos = transform.position;
        pos.z -= 1f;
        downRay = new Ray(pos, transform.up);
    }

    void Update()
    {
        // We get them in this order because:
        //      -- we want to rotate around the x axis when the user presses up or down ("vertical") (mirrored)
        //      -- we want to rotate around the y axis when the user presses left or right ("horizontal")
        //      -- never rotate around the z axis (twisting)
        Vector3 input = new Vector3(-Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        input.Normalize();

        if (input.magnitude > 0)
        {
            planetObject.transform.Rotate(input * RotationSpeed * Time.deltaTime, Space.World);
        }
    
        if (Input.GetKey(KeyCode.Space))
        {
            jetpacking = true;
        }
        else jetpacking = false;

        // Safeguard
        if (Physics.Raycast(downRay, out hitInfo, planet.PlanetRadius + JumpMaxHeight, ~raycastIgnore))
        {
            // Destroy enemies if you float over them
            if (hitInfo.collider.CompareTag("Obstacle") && jetpacking) Destroy(hitInfo.collider.gameObject);
            if (hitInfo.collider.CompareTag("Planet"))
            {
                Height = hitInfo.point.z - 1.5f;
            }
        }

        Debug.DrawRay(pos, transform.up * (planet.PlanetRadius + JumpMaxHeight), Color.green);

        // Snap to ground
        if (transform.position.z > Height)
        {
            transform.Translate(transform.forward * (transform.position.z - Height));
        }

        // Provides look vector
        lookVector = new Vector2(-input.x, input.y);
        if (lookVector.magnitude == 0) lookAngle = 0;
        else lookAngle = Mathf.Rad2Deg * Mathf.Atan2(lookVector.y, lookVector.x);

        FlorbusModel.transform.eulerAngles = new Vector3(180, 0, lookAngle);
    }

    private void FixedUpdate()
    {
        if (jetpacking && jumpSeconds > 0f)
        {
            // using forward because the player is rotated and the axes are different
            if (transform.position.z - JetpackSpeed * Time.fixedDeltaTime > NormalHeight - JumpMaxHeight)
                transform.Translate(transform.forward * JetpackSpeed * Time.fixedDeltaTime);
            else transform.position = maxHeightVector;
            jumpSeconds -= Time.fixedDeltaTime;
        }
        else if (transform.position.z + JetpackSpeed * Time.fixedDeltaTime < Height)
        {
            // Jetpack down for free
            transform.Translate(-transform.forward * FallSpeed * Time.fixedDeltaTime);
        }
    }
}
