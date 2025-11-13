using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 250f;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    public void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    public void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    public void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    public void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    
    public void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - laser.transform.position;    // subtracting laser position from target position, return vector between laser and target point
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);       // calculate rotation for laser and align it to vector that we calculated
            laser.transform.rotation = rotationToTarget;                                // move the lasers' rotation towards the quaternion
        }
    }
}
