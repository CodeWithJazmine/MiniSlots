using UnityEngine;

[System.Serializable]
public class Symbol
{
    [SerializeField] private string Name;
    [SerializeField] private int Payout;
    [SerializeField] private Sprite Sprite; 

    // Constructor to initialize the symbol name and payout
    public Symbol(string name, int payout, Sprite sprite)
    {
        Name = name;
        Payout = payout;
        Sprite = sprite;
    }

    // Properties to access the symbol name, payout, and sprite
    public string GetName()
    {
        return Name;
    }
    public int GetPayout()
    {
        return Payout;
    }
    public Sprite GetSprite()
    {
        return Sprite;
    }
}
