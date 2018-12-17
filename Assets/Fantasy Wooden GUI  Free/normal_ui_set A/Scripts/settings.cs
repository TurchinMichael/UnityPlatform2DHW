using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour {

    public Slider volume, musicVolume;
    public AudioSource music;
    safeItems safe;

    // Use this for initialization
    void Awake ()
    {
        volume.maxValue = 1;// mainListener.vol
        volume.minValue = 0;
        musicVolume.maxValue = 1;
        musicVolume.minValue = 0;
        //volume.value = AudioListener.volume;
        //musicVolume.value = music.volume;

        safe = FindObjectOfType<safeItems>();

        musicVolume.value = safe.MusicValue;
        volume.value = safe.VolumeValue;

        AudioListener.volume = volume.value;
        music.volume = musicVolume.value;
    }

    // Update is called once per frame
    void Update ()
    {
        safe.VolumeValue = volume.value;
        AudioListener.volume = safe.VolumeValue;

        safe.MusicValue = musicVolume.value;
        music.volume = safe.MusicValue;
    }
}
