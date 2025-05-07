using System.Collections;
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
        StartCoroutine(WaitAndCheckWin());
        Debug.Log($"Spinning... Current Credits: {PlayerCredits}");
    }
    public IEnumerator WaitAndCheckWin()
    {
        // Wait for the reels to stop spinning
        float totalWaitTime = ReelManager.GetTotalSpinTime();
        yield return new WaitForSeconds(totalWaitTime);

        // Check for win after all reels have stopped
        CheckWin();
    }
    public void CheckWin()
    {
        int Sym1 = ReelManager.GetReel(0).GetSymbol().GetPayout();
        int Sym2 = ReelManager.GetReel(1).GetSymbol().GetPayout();
        int Sym3 = ReelManager.GetReel(2).GetSymbol().GetPayout();

        // All three symbols must match
        if (Sym1 == Sym2 && Sym2 == Sym3)
        {
            AddCredits(Sym1 * BetAmount); // Payout is the symbol value times the bet amount
            Debug.Log($"Jackpot! Payout: {Sym1 * BetAmount}. Current Credits: {PlayerCredits}");
        }
        // Two symbols match
        else if (Sym1 == Sym2 || Sym1 == Sym3 || Sym2 == Sym3)
        {
            int Payout = 0;

            if (Sym1 == Sym2) Payout = Sym1;
            else if (Sym1 == Sym3) Payout = Sym1;
            else if (Sym2 == Sym3) Payout = Sym2;

            Payout *= (BetAmount / 2); // Payout is half the bet amount
            AddCredits(Payout);
            Debug.Log($"Partial Win! Payout: {Payout}. Current Credits: {PlayerCredits}");
        }
        // No win
        else
        {
            Debug.Log("No win this time.");
        }
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
