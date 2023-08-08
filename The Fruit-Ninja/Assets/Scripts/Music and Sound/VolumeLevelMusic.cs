using UnityEngine;

public class VolumeLevelMusic : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        source.volume = VolumeSettings.musicLevel;
    }
}
