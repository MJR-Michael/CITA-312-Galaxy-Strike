using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedShipVFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedShipVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
