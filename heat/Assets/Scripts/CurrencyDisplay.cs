using UnityEngine;
using TMPro;

public class CurrencyDisplay : MonoBehaviour
{
    public TMP_Text currencyText;
    public int playerCurrency = 100; // Baþlangýç parasý

    void Update()
    {
        currencyText.text = "Money: $" + playerCurrency;
    }
}
