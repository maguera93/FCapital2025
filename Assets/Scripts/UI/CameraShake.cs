using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private bool shake;
    private bool startShake;
    private Vector3 originPosition;
    private Quaternion originRotation;

    [SerializeField]
    protected GlobalVariables m_globalVariables;

    private bool endShake; // Check if shake is end.
    private bool isShaking; // Check if camera is shaking right now.
    private float shakingForce; // Initial force.
    private float shakeDecay; // Decay force.

    private void Awake()
    {
        originPosition = transform.position;
        m_globalVariables.OnEnemyHit += DoShake;
        m_globalVariables.OnPlayerHit += DoSuperShake;
    }

    private void OnDestroy()
    {
        m_globalVariables.OnEnemyHit -= DoShake;
        m_globalVariables.OnPlayerHit -= DoSuperShake;
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
    public void DoSuperShake()
    {
        shakingForce = 0.5F;
        shakeDecay = 0.2F;
        startShake = true;
    }
}