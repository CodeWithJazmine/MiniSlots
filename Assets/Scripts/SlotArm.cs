using UnityEngine;
using UnityEngine.UI;

public class SlotArm : MonoBehaviour
{

    [Header("Slot Arm Settings")]
    [SerializeField] private GameObject SlotArmUp;
    [SerializeField] private GameObject SlotArmDown;

    public void PullSlotArm()
    {
        // Switch the arm positions
        SlotArmUp.SetActive(false);
        SlotArmDown.SetActive(true);

        // Call the GameManager's PlaySpin method
        GameManager.Instance.PlaySpin();

        // Reset the arm back after a delay
        Invoke(nameof(ResetSlotArm), 0.5f);
    }

    private void ResetSlotArm()
    {
        // Switch the arm positions back
        SlotArmUp.SetActive(true);   
        SlotArmDown.SetActive(false);
    }
 
}
