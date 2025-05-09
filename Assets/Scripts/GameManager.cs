using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsSpinning {get; private set;} 

    [Header(("References"))]
    [SerializeField] private ReelManager ReelManager;

    [Header(("Game State"))]
    [SerializeField] private int PlayerCredits = 100;
    [SerializeField] private int BetAmount = 10;
    private int Payout = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
    }
    private void Start()
    {
        ReelManager.OnSpinComplete += OnReelsFinished;
    }

    [ContextMenu("Play Spin")]
    public void PlaySpin()
    {
        if (PlayerCredits < BetAmount || IsSpinning)
        {
            Debug.Log("Not enough credits to spin or already spinning.");
            return;
        }

        AddCredits(-BetAmount); // Deduct the bet amount from player credits
        IsSpinning = true;
        ReelManager.SpinAllReels();
    }

    public void OnReelsFinished()
    {
        IsSpinning = false;
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
            Payout = Sym1 * BetAmount; // Payout is the symbol value times the bet amount
            AddCredits(Sym1 * BetAmount); 
            Debug.Log($"Jackpot! Payout: {Payout}. Current Credits: {PlayerCredits}");
        }
        // Two symbols match
        else if (Sym1 == Sym2 || Sym1 == Sym3 || Sym2 == Sym3)
        {
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

    public int GetBetAmount()
    {
        return BetAmount;
    }

    public void SetBetAmount(int amount)
    {
        if (amount > 0)
        {
            BetAmount = amount;
        }
        else
        {
            Debug.LogError("Bet amount must be greater than zero.");
        }
    }

    public void ResetCredits()
    {
        PlayerCredits = 100; // Reset to default value
    }

    public void ResetBetAmount()
    {
        BetAmount = 10; // Reset to default value
    }
   public int GetPayout()
    {
        return Payout;
    }
    
    public void AddCredits(int amount)
    {
        PlayerCredits += amount;
    }
}
