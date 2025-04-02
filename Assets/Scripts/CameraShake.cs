using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject CameraObject;
    public float ShakeAmount;
    public float ShakeSpeed;
    float time;
    float shakeDuration;
    bool isShaking;

    Vector3 pos;
    void Start()
    {
        isShaking = false;
        time = 0;
        shakeDuration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            pos.x = Mathf.Cos(time * ShakeSpeed) * ShakeAmount;
            pos.y = Mathf.Sin(time * ShakeSpeed) * ShakeAmount;

            CameraObject.transform.localPosition = pos;

            time += Time.deltaTime;
            if (time >= shakeDuration)
            {
                isShaking = false;
                pos = Vector3.zero;
                CameraObject.transform.localPosition = Vector3.zero;
                time = 0;
            }
        }
    }

    public void Shake(float dur)
    {
        isShaking = true;
        shakeDuration = dur;
    }
}
