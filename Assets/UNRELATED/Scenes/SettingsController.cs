using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public AudioMixer mx;
    public TMPro.TMP_Dropdown resDropDown;
    Resolution[] res;
    void Start()
    {
        resDropDown.ClearOptions();
        res = Screen.resolutions;

        List<string> Option = new List<string>();
        int currentRes = 0;
        for (int i = 0; i < res.Length; i++)
        {
            string resolutionInstring = res[i].width + " x " + res[i].height;
            Option.Add(resolutionInstring);
            if (res[i].width == Screen.currentResolution.width && res[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }
        resDropDown.AddOptions(Option);
        resDropDown.value = currentRes;
        resDropDown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {

        mx.SetFloat("Volume", volume);
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution newRes = res[resolutionIndex];
        Screen.SetResolution(newRes.width, newRes.height, true);

    }
}
