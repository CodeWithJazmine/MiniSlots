using UnityEngine;

public class BetButtons : MonoBehaviour
{
    public void PlusButton()
    {
        if (GameManager.Instance.IsSpinning) return; // Prevent input if the reels are spinning
        GameManager.Instance.AddBetAmount(5);
    }

    public void MinusButton()
    {
        if (GameManager.Instance.IsSpinning) return; // Prevent input if the reels are spinning
        GameManager.Instance.AddBetAmount(-5);
    }
}
