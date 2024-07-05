using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.maxValue = 50;
        slider.value = 50;
    }

    public void DecreaseHeat(float amount)
    {
        slider.value -= amount;
        if (slider.value <= 0)
        {
            // Handle what happens when heat bar reaches zero
        }
    }
}
