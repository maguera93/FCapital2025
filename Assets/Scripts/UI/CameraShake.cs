using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private bool shake;
    private bool startShake;
    private Vector3 originPosition;
    private Quaternion originRotation;


    private bool endShake; // Check if shake is end.
    private bool isShaking; // Check if camera is shaking right now.
    private float shakingForce; // Initial force.
    private float shakeDecay; // Decay force.

    private void Awake()
    {
        originPosition = transform.position;
        GlobalVariables.instance.OnEnemyHit += DoShake;
    }

    // Update is called once per frame
    void Update()
    {
        //SHAKE
        if (startShake)
        {
            isShaking = true;
            startShake = false;
            shake = true;
        }
        else if (shake && !endShake)
        {
            if (shakingForce > 0)
            {
                transform.position = transform.position + Random.insideUnitSphere * shakingForce;
                shakingForce -= shakeDecay;
            }
            else endShake = true;
        }
        else if (endShake)
        {
            shake = false;
            isShaking = false;

            transform.position = originPosition;

            endShake = false;
        }
    }

    public void DoShake()
    {
        shakingForce = 0.1F;
        shakeDecay = 0.05F;
        startShake = true;
    }
}