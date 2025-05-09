using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI CreditsAmount;
    [SerializeField] private TextMeshProUGUI BetAmount;
    [SerializeField] private TextMeshProUGUI PayoutAmount;

    private void Start()
    {
        GameManager.Instance.OnCreditsChanged += UpdateCredits;
        GameManager.Instance.OnBetAmountChanged += UpdateBetAmount;
        GameManager.Instance.OnPayoutChanged += UpdatePayout;

        // Initialize UI with default values
        UpdateCredits(GameManager.Instance.GetCredits());
        UpdateBetAmount(GameManager.Instance.GetBetAmount());
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCreditsChanged -= UpdateCredits;
        GameManager.Instance.OnBetAmountChanged -= UpdateBetAmount;
        GameManager.Instance.OnPayoutChanged -= UpdatePayout;
    }

    private void UpdateCredits(int newCredits)
    {
        CreditsAmount.text = newCredits.ToString();
    }

    private void UpdateBetAmount(int newBetAmount)
    {
        BetAmount.text = newBetAmount.ToString();
    }

    private void UpdatePayout(int newPayout)
    {
        PayoutAmount.text = newPayout.ToString();
    }
}
