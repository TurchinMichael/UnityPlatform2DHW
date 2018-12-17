using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeItems : MonoBehaviour {
    float music = 0.5f, volume = 0.5f;
    
    public float VolumeValue
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
        }
    }

    public float MusicValue
    {
        get
        {
            return music;
        }
        set
        {
            music = value;
        }
    }
}