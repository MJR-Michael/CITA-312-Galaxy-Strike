using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed;
    [SerializeField] private float xClampRange;

    // we have specific negY and posY clamps because the ship is not centered in the screen in terms of y.
    [SerializeField] private float negYClampRange;
    [SerializeField] private float posYClampRange;


    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
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
        float clampedYPos = Mathf.Clamp(rawYPos, negYClampRange, posYClampRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
}
