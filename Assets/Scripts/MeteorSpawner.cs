using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject Meteor;
    public GameObject HitPoint;
    public Planet planet;
    public float TimeBetweenSpawns;
    public float MeteorVelocity;
    public float SpawnDistance;

    public Vector3 spawningLimitsMin;
    public Vector3 spawningLimitsMax;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", TimeBetweenSpawns, TimeBetweenSpawns);
    }

    void SpawnMeteor()
    {
        // generate 3 random angles as degrees for x, y, z rot
        // Using limits defined so it always spawns on the front side
        Vector3 angles = new Vector3(Mathf.Lerp(spawningLimitsMin.x, spawningLimitsMax.x, Random.value), 
            Mathf.Lerp(spawningLimitsMin.y, spawningLimitsMax.y, Random.value),
            Mathf.Lerp(spawningLimitsMin.z, spawningLimitsMax.z, Random.value));
        // Represent rotation as a quaternion
        Quaternion quat = Quaternion.Euler(angles.x, angles.y, angles.z);
        Vector3 dir = quat * Vector3.forward;

        GameObject hitPos = Instantiate(HitPoint);
        hitPos.transform.parent = transform;
        hitPos.transform.position = dir * planet.PlanetRadius;

        GameObject prefab = Instantiate(Meteor);
        prefab.transform.parent = transform;
        prefab.transform.position = dir * SpawnDistance;
        prefab.transform.rotation = quat;

        Meteor meteor = prefab.GetComponent<Meteor>();
        meteor.Velocity = MeteorVelocity;
        meteor.hitPosition = hitPos;

    }
}
