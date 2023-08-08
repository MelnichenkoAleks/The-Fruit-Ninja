using UnityEngine;

public class VolumeLevelSound : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        source.volume = VolumeSettings.soundLevel;
    }
}
