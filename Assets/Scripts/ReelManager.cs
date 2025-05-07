using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ReelManager: MonoBehaviour
{
    [Header("Reel Settings")]
    [SerializeField] private Reel[] Reels;

    [Header("Spin Timing")]
    [SerializeField] private float SpinDuration = 3.0f;
    [SerializeField] private float StopDelayIncrement = 0.5f;

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
    }
}
