using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public GameObject movementJoystick; // Asigna el joystick de movimiento desde el Inspector
    public GameObject viewJoystick; // Asigna el joystick de vista desde el Inspector

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float screenHalf = Screen.width / 2f;

            if (touch.position.x < screenHalf)
            {
                movementJoystick.SetActive(true);
                //viewJoystick.SetActive(false);
            }
            else
            {
                //movementJoystick.SetActive(false);
                viewJoystick.SetActive(true);
            }
        }
    }
}
