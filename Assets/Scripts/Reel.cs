using System.Collections;
using UnityEngine;
public class Reel : MonoBehaviour
{
    [Header("Symbol Settings")] // Assign these in the inspector
    [SerializeField] private Sprite[] SymbolSprites;
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
        GetRandomSymbol();
    }

    public int GetSymbolIndex()
    {
        return CurrentIndex;
    }

    public Sprite GetSymbolSprite()
    {
        return SymbolSprites[CurrentIndex];
    }

    private void GetRandomSymbol()
    {
        CurrentIndex = UnityEngine.Random.Range(0, SymbolSprites.Length);
        SymbolRenderer.sprite = SymbolSprites[CurrentIndex];
    }
}
