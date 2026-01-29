using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SliderText : MonoBehaviour
{
    float result;
    [SerializeField] public TextMeshProUGUI percent_count = null;
    [SerializeField] public float max_slider = 100.0f;

    public void Slider_volume(float Volume)
    {
        float result;
        result = Volume * max_slider;
        percent_count.text = Volume.ToString("0");
    }

}
