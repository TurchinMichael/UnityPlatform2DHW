using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour {

    public Slider volume, musicVolume;
    public AudioSource music;

    // Use this for initialization
    void Start ()
    {
        volume.maxValue = 1;// mainListener.vol
        volume.minValue = 0;
        musicVolume.maxValue = 1;
        musicVolume.minValue = 0;
        volume.value = AudioListener.volume;
        musicVolume.value = music.volume;
    }

    // Update is called once per frame
    void Update ()
    {
        AudioListener.volume = volume.value;
        music.volume = musicVolume.value;
    }
}
