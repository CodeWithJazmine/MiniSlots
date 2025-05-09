using System;
using System.Collections;
using UnityEngine;

// Delegates for events
public delegate void SpinCompleteHandler();

public class ReelManager: MonoBehaviour
{
    [Header("Reel Settings")]
    [SerializeField] private Reel[] Reels;

    [Header("Spin Timing")]
    [SerializeField] private float SpinDuration = 3.0f;
    [SerializeField] private float StopDelayIncrement = 0.5f;

    // Events for UI updates
    public event SpinCompleteHandler OnSpinComplete;

    [ContextMenu("SpinAllReels")]
    public void SpinAllReels()
    {
        // Start the coroutine to spin all reels
        StartCoroutine(SpinAllReelsCoroutine());
    }

    private IEnumerator SpinAllReelsCoroutine()
    {

        // Start spinning all reels
        foreach (Reel reel in Reels)
        {
            reel.SpinWithAnimation();
        }

        // Wait for the spin duration before stopping one by one
        yield return new WaitForSeconds(SpinDuration);

        // Stop each reel with a delay 
        for (int i = 0; i < Reels.Length; i++)
        {
            Reels[i].StopSpinning();
            yield return new WaitForSeconds(StopDelayIncrement);
        }

        // Notify that the spin is complete to any listeners
        OnSpinComplete?.Invoke();
    }
    
    public Reel GetReel(int index)
    {
        if (index < 0 || index >= Reels.Length)
        {
            Debug.LogError("Reel index out of bounds.");
            return null;
        }
        return Reels[index];
    }
}
