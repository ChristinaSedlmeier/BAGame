using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        Debug.Log("MaxHealth is: " + health);
        fill.color = gradient.Evaluate(1f);

        
    }

    public void SetHealth(int health)
    {
        Debug.Log("slider is: " + slider.value);
        Debug.Log("Health is: " + health);

        slider.value = health;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}
