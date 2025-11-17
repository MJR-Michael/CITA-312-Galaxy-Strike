using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedShipVFX;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedShipVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
}
