using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour
{
    public Slider slider;
    private Image fillImage; // Slider'�n doldurma resmi

    // Renk ge�i�lerinde kullan�lacak renkler
    private Color[] heatColors = new Color[]
    {
        Color.white,                         // Beyaz
        new Color(1f, 0.92f, 0.016f),        // A��k Sar�
        Color.yellow,                        // Sar�
        new Color(1f, 0.54f, 0f),            // Sar�ms� Turuncu
        new Color(1f, 0.64f, 0f),            // Turuncu
        new Color(1f, 0.27f, 0f),            // Turuncumsu K�rm�z�
        Color.red                            // K�rm�z�
    };

    void Start()
    {
        slider.maxValue = 20;
        slider.value = 0; // Ba�lang�� de�erini 0 olarak ayarlay�n veya istedi�iniz ba�lang�� de�erini buradan belirleyin

        fillImage = slider.fillRect.GetComponent<Image>(); // Slider'�n doldurma resmini al�n
        UpdateHeatColor(); // Ba�lang��ta renk g�ncellemesini yap�n
    }

    public void IncreaseHeat(float amount)
    {
        slider.value += amount;
        if (slider.value >= slider.maxValue)
        {
            // Heat bar maximum de�ere ula�t���nda yap�lacak i�lemler
            slider.value = slider.maxValue; // De�eri max de�ere sabitleyin (opsiyonel)
        }

        UpdateHeatColor(); // Her art��ta renk g�ncellemesini yap�n
    }

    // Slider'�n rengini g�ncelleyen fonksiyon
    private void UpdateHeatColor()
    {
        // Heat bar�n rengini de�ere g�re belirleyin
        float normalizedValue = slider.normalizedValue; // 0 ile 1 aras�nda normalle�tirilmi� de�er
        int colorIndex = Mathf.FloorToInt(normalizedValue * (heatColors.Length - 1)); // Renk dizisinin indeksi
        fillImage.color = heatColors[colorIndex]; // Slider'�n doldurma resmine renk atay�n
    }
}
