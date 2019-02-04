using UnityEngine;
using UnityEngine.UI;

public class AudioSliderNode : MonoBehaviour
{
    public enum SliderType
    {
        MasterVolume,
        MusicVolume,
        UIVolume
    }

    private Slider slider;

    public SliderType sliderType;

    void Awake ()
    {
        slider = gameObject.GetComponent<Slider>();
        UpdateSliders();
    }

    void Start ()
    {
        // Attatch listener onto slider
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    void UpdateSliders ()
    {
        switch (sliderType)
        {
            case SliderType.MasterVolume:
                slider.value = AudioManager.instance.masterVolume;
                break;

            case SliderType.MusicVolume:
                slider.value = AudioManager.instance.musicVolume;
                break;

            case SliderType.UIVolume:
                slider.value = AudioManager.instance.uiVolume;
                break;

            default:
                break;
        }
    }

    void ValueChangeCheck ()
    {
        UpdateSliders();
    }
}
