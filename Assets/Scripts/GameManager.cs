using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header(("References"))]
    [SerializeField] private ReelManager ReelManager;

    [Header(("Game State"))]
    [SerializeField] private int PlayerCredits = 100;
    [SerializeField] private int BetAmount = 10;

    [ContextMenu("Play Spin")]
    public void PlaySpin()
    {
        if (PlayerCredits < BetAmount)
        {
            Debug.Log("Not enough credits to spin.");
            return;
        }

        PlayerCredits -= BetAmount;
        ReelManager.SpinAllReels();

        Debug.Log($"Spinning... Current Credits: {PlayerCredits}");
    }

    public int GetCredits()
    {
        return PlayerCredits;
    }

    public void AddCredits(int amount)
    {
        PlayerCredits += amount;
    }
}
