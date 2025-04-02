using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject SpawningPrefab;
    public GameObject SpawningO2;
    public GameObject SpawningFuel;
    public int NumPrefabs;
    public int NumO2;
    public int NumFuel;
    public float PlanetRadius = 20f;
    void Start()
    {
        for (int i = 0; i < NumPrefabs; i++)
        {
            // generate 3 random angles as degrees for x, y, z rot
            Vector3 angles = new Vector3(Random.value * 360f, Random.value * 360f, Random.value * 360f);
            // Represent rotation as a quaternion
            Quaternion quat = Quaternion.Euler(angles.x, angles.y, angles.z);
            Vector3 dir = quat * Vector3.forward;
            Debug.DrawRay(Vector3.zero, dir * (PlanetRadius + 1), Color.red, 10f);

            GameObject prefab = Instantiate(SpawningPrefab);
            prefab.transform.parent = transform;
            prefab.transform.position = dir * (PlanetRadius + prefab.transform.localScale.y);
            Quaternion lookQuat = Quaternion.LookRotation(quat * Vector3.up, dir);
            prefab.transform.rotation = lookQuat;
        }

        for (int i = 0; i < NumO2; i++)
        {
            // generate 3 random angles as degrees for x, y, z rot
            Vector3 angles = new Vector3(Random.value * 360f, Random.value * 360f, Random.value * 360f);
            // Represent rotation as a quaternion
            Quaternion quat = Quaternion.Euler(angles.x, angles.y, angles.z);
            Vector3 dir = quat * Vector3.forward;
            Debug.DrawRay(Vector3.zero, dir * (PlanetRadius + 1), Color.red, 10f);

            GameObject prefab = Instantiate(SpawningO2);
            prefab.transform.parent = transform;
            prefab.transform.position = dir * (PlanetRadius + prefab.transform.localScale.y);
            prefab.transform.rotation = quat;
        }

        for (int i = 0; i < NumFuel; i++)
        {
            // generate 3 random angles as degrees for x, y, z rot
            Vector3 angles = new Vector3(Random.value * 360f, Random.value * 360f, Random.value * 360f);
            // Represent rotation as a quaternion
            Quaternion quat = Quaternion.Euler(angles.x, angles.y, angles.z);
            Vector3 dir = quat * Vector3.forward;
            Debug.DrawRay(Vector3.zero, dir * (PlanetRadius + 1), Color.red, 10f);

            GameObject prefab = Instantiate(SpawningFuel);
            prefab.transform.parent = transform;
            prefab.transform.position = dir * (PlanetRadius + prefab.transform.localScale.y);
            prefab.transform.rotation = quat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
