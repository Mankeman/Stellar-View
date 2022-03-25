using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    //Audio Mixers are used for keeping the respective sounds in their categories
    //You also need to expose certain parameters for them to be manipulated.
    [Header("AudioInfo")]
    public AudioMixer musicMixer;
    public AudioMixer effectMixer;
    public string musicExposedParam;
    public string SFXExposedParam;
    public void SetMusicLevel(float musicSliderValue)
    {
        musicMixer.SetFloat(musicExposedParam, Mathf.Log10(musicSliderValue) * 20);
    }
    public void SetSFXLevel(float effectSliderValue)
    {
        effectMixer.SetFloat(SFXExposedParam, Mathf.Log10(effectSliderValue) * 20);
    }
}
