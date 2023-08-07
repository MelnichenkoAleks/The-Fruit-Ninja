using UnityEngine.UI;
using UnityEngine;

public class SoundSlider : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.value = VolumeSettings.soundLevel;
    }

    void Update()
    {
        VolumeSettings.soundLevel = slider.value;
    }
}
