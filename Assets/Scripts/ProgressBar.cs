using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider; 
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetValue(float value)
    {
        slider.value = value;
    }
}
