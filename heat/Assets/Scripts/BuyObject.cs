using UnityEngine;

public class BuyObject : MonoBehaviour
{
    public float buyDistance = 1.0f;
    public int objectPrice = 10;
    public GameObject replacementPrefab; // Satýn alýndýðýnda yerleþtirilecek prefab
    public Transform player; // Oyuncu transformu

    private CurrencyDisplay currencyDisplay;

    void Start()
    {
        currencyDisplay = FindObjectOfType<CurrencyDisplay>(); // CurrencyDisplay script'ini bul
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < buyDistance && currencyDisplay.playerCurrency >= objectPrice)
        {
            // Satýn alma iþlemi
            currencyDisplay.playerCurrency -= objectPrice;

            // Yeni konum hesaplama
            Vector3 newPosition = new Vector3(
                transform.position.x + 1163.6f,
                transform.position.y + 538.7f,
                transform.position.z - 26.7f
            );

            // Yeni prefab'ý oluþturma
            Instantiate(replacementPrefab, newPosition, transform.rotation);

            // Eski nesneyi deaktif etme
            gameObject.SetActive(false);
        }
    }
}
