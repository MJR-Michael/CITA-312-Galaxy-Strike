using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    public void Update()
    {
        ProcessFiring();
        MoveCrosshair();
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
}
