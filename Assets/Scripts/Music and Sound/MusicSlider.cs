using UnityEngine.UI;
using UnityEngine;

public class MusicSlider : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.value = VolumeSettings.musicLevel;
    }

    void Update()
    {
        VolumeSettings.musicLevel = slider.value;
    }
}
