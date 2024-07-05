using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour
{
    public Slider slider;
    private Image fillImage; // Slider'ýn doldurma resmi

    // Renk geçiþlerinde kullanýlacak renkler
    private Color[] heatColors = new Color[]
    {
        Color.white,                         // Beyaz
        new Color(1f, 0.92f, 0.016f),        // Açýk Sarý
        Color.yellow,                        // Sarý
        new Color(1f, 0.54f, 0f),            // Sarýmsý Turuncu
        new Color(1f, 0.64f, 0f),            // Turuncu
        new Color(1f, 0.27f, 0f),            // Turuncumsu Kýrmýzý
        Color.red                            // Kýrmýzý
    };

    void Start()
    {
        slider.maxValue = 20;
        slider.value = 0; // Baþlangýç deðerini 0 olarak ayarlayýn veya istediðiniz baþlangýç deðerini buradan belirleyin

        fillImage = slider.fillRect.GetComponent<Image>(); // Slider'ýn doldurma resmini alýn
        UpdateHeatColor(); // Baþlangýçta renk güncellemesini yapýn
    }

    public void IncreaseHeat(float amount)
    {
        slider.value += amount;
        if (slider.value >= slider.maxValue)
        {
            // Heat bar maximum deðere ulaþtýðýnda yapýlacak iþlemler
            slider.value = slider.maxValue; // Deðeri max deðere sabitleyin (opsiyonel)
        }

        UpdateHeatColor(); // Her artýþta renk güncellemesini yapýn
    }

    // Slider'ýn rengini güncelleyen fonksiyon
    private void UpdateHeatColor()
    {
        // Heat barýn rengini deðere göre belirleyin
        float normalizedValue = slider.normalizedValue; // 0 ile 1 arasýnda normalleþtirilmiþ deðer
        int colorIndex = Mathf.FloorToInt(normalizedValue * (heatColors.Length - 1)); // Renk dizisinin indeksi
        fillImage.color = heatColors[colorIndex]; // Slider'ýn doldurma resmine renk atayýn
    }
}
