using TMPro;
using UnityEngine;

public class UiCoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private CoinsDataSo coinsData;
    private int coinsInGame;

    private void OnEnable()
    {
        PickablesController.onCoinsPicked += OnCoinsChanged_WriteCoins;
    }

    private void Start()
    {
        coinsInGame = coinsData.coins;
        coinsData.coins = coinsInGame;
        coinsText.text = coinsData.coins.ToString("0");
    }

    private void OnDisable()
    {
        PickablesController.onCoinsPicked -= OnCoinsChanged_WriteCoins;
    }

    public void OnCoinsChanged_WriteCoins(PickablesController pickablesController)
    {
        int coinPickedValue = coinsData.coinsValue;
        coinsData.coins += coinPickedValue;
        coinsData.totalCoins += coinPickedValue;
        coinsText.text = coinsData.coins.ToString("0");
    }
}
