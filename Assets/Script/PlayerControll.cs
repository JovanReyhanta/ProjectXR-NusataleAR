using UnityEngine;
using UnityEngine.InputSystem; // Wajib ada

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;

    // PASTIKAN ada kata 'public' dan parameternya 'InputAction.CallbackContext'
    public void OnMove(InputAction.CallbackContext context)
    {
        // Membaca nilai Vector2 dari joystick
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        // Logika pergerakan sederhana
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime);
    }
}