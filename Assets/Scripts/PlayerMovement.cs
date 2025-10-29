using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed;
    [SerializeField] private float xClampRange;
    [SerializeField] private float yClampRange;

    [SerializeField] private float controlRollFactor = 30f; // the angle in which we turn left/right
    [SerializeField] private float controlPitchFactor = 40f; // the angle in which we turn up/down

    [SerializeField] private float rotationSpeed; 

    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffSet = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffSet = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        float roll = -controlRollFactor * movement.x;
        float pitch = -controlPitchFactor * movement.y;
        float yaw = 0f;

        Quaternion targetRotation = Quaternion.Euler( pitch, yaw, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
