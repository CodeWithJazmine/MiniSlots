using UnityEngine;

[System.Serializable]
public class Symbol
{
    public string Name;
    public int Payout;
    public Sprite Sprite; 

    // Constructor to initialize the symbol name and payout
    public Symbol(string name, int payout, Sprite sprite)
    {
        Name = name;
        Payout = payout;
        Sprite = sprite;
    }
}
