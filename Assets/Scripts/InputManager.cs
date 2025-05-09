using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions InputActions;

    private void Awake()
    {
        InputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        InputActions.Enable();
        InputActions.Player.Click.performed += OnClick;
    }

    private void OnDisable()
    {
        InputActions.Player.Click.performed -= OnClick;
        InputActions.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        // Prevent input if the reels are spinning
        if (GameManager.Instance.IsSpinning) return;

        // Get the mouse position 
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        // Check if the raycast hit a collider with the "SlotArm" tag
        if (hit.collider != null && hit.collider.CompareTag("SlotArm"))
        {
            SlotArm SlotArm = hit.collider.GetComponentInParent<SlotArm>();
            if (SlotArm != null)
            {
                SlotArm.PullSlotArm();
            }
        }   
    }
}
