using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour {

    public AudioMixer mixer;
    public AudioMixer soundFx;

    public void ChangeVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }
    public void ChangeSoundFx(float sound)
    {
        soundFx.SetFloat("soundfx", sound);
    }

    public void SetQualityGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }

    public void BloodGore(bool bloody)
    {
        Debug.Log("Turn off blood animation");
        // Animation turn off 
    }
}
