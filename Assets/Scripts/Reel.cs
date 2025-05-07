using System.Collections;
using UnityEngine;

public class Reel : MonoBehaviour
{
    [Header("Symbol Settings")] // Assign these in the inspector
    [SerializeField] private Sprite[] SymbolSprites;
    [SerializeField] private SpriteRenderer SymbolRenderer;
    private int CurrentIndex; // The index of symbol landed on

    [Header("Spin Settings")]
    [SerializeField] private float SpinDuration = 3.0f;

    [ContextMenu("Spin")]
    public void Spin()
    {
        CurrentIndex = UnityEngine.Random.Range(0, SymbolSprites.Length);
        SymbolRenderer.sprite = SymbolSprites[CurrentIndex];
    }

    [ContextMenu("SpinWithAnimation")]
    public void DebugSpinWithAnimation()
    {
        StartCoroutine(SpinWithAnimation(SpinDuration));
    }
    private IEnumerator SpinWithAnimation(float Duration)
    {
        float ElapsedTime = 0.0f;
        
        // Displaying random symbols for the Duration
        while(ElapsedTime < Duration)
        {
            int RandomIndex = Random.Range(0, SymbolSprites.Length);
            SymbolRenderer.sprite = SymbolSprites[RandomIndex];
            yield return new WaitForSeconds(0.05f);
            ElapsedTime += 0.1f;
        }

        // Display the symbol
        CurrentIndex = UnityEngine.Random.Range(0, SymbolSprites.Length);
        SymbolRenderer.sprite = SymbolSprites[CurrentIndex];
    }

    public int GetSymbolIndex()
    {
        return CurrentIndex;
    }

    public Sprite GetSymbolSprite()
    {
        return SymbolSprites[CurrentIndex];
    }
}
