using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sliderChange : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void setHealthMax(int health){
            slider.maxValue = health;
            slider.value = health;
            fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setHealth(int health){
            slider.value = health;
            fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
