using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    bool isFiring = false;

    public void Update()
    {
        ProcessFiring();
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
}
