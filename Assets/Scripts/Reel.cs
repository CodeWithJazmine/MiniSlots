using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reel : MonoBehaviour
{
    [Header("Symbol Settings")] // Assign these in the inspector
    [SerializeField] private List<Symbol> Symbols; // List of symbols to choose from
    [SerializeField] private SpriteRenderer SymbolRenderer;
    private int CurrentIndex; // The index of symbol landed on

    [Header("Spin Settings")]
    [SerializeField] private float SpinSpeed = 0.05f; // How fast the symbol changes during a spin
    
    private bool IsSpinning = false;

    [ContextMenu("Spin")]
    public void Spin()
    {
        GetRandomSymbol();
    }

    public void SpinWithAnimation()
    {
        if (IsSpinning) return; // Prevent multiple spins at the same time
        StartCoroutine(SpinCoroutine());
    }
    private IEnumerator SpinCoroutine()
    {
        IsSpinning = true;

        while (IsSpinning)
        {
            GetRandomSymbol();
            yield return new WaitForSeconds(SpinSpeed);
        }
    }

    public void StopSpinning()
    {
        IsSpinning = false;
    }

    public int GetSymbolIndex()
    {
        return CurrentIndex;
    }

    public Symbol GetSymbol()
    {
        return Symbols[CurrentIndex];
    }

    private void GetRandomSymbol()
    {
        CurrentIndex = UnityEngine.Random.Range(0, Symbols.Count);
        SymbolRenderer.sprite = Symbols[CurrentIndex].GetSprite();
    }
}
