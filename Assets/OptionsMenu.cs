using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public Dropdown _dropDown;
    Resolution[] resolutions;
    public void Start()
    {
        resolutions = Screen.resolutions;

        _dropDown.ClearOptions();
        List<string> _options = new List<string>();
        int _currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            _options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                _currentResolutionIndex = i;
            }

        }
        _dropDown.AddOptions(_options);
        _dropDown.value = _currentResolutionIndex;
        _dropDown.RefreshShownValue();

    }
    public void SetVolumen(float volumen)
    {
        _audioMixer.SetFloat("Volume", volumen);
    }
    public void GraphicQualityChange(int quality){
        QualitySettings.SetQualityLevel(quality);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


    }
    public void SetFullScreen(bool _isFullScreen)
    {
        Screen.fullScreen = _isFullScreen;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}
