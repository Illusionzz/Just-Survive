using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Dropdown resolutiondropDown;

    Resolution[] resolutions;

    private MainMenu menu;

    void Awake()
    {
        menu = GetComponent<MainMenu>();
    }

    void Start()
    {
        //if theres no saved volume settings
        if (!PlayerPrefs.HasKey("masterVolume")) {
            PlayerPrefs.SetFloat("masterVolume", 1);
            LoadVolume();
        }
        else {
            LoadVolume();
        }

        GetResolution();
    }

    public void BackButton() 
    {
        menu.optionsPanel.SetActive(false);
    }
//VOLUME SETTINGS
    public void SetVolume(float volume) 
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    void SaveVolume() 
    {
        PlayerPrefs.SetFloat("masterVolume", volumeSlider.value);
    }

   void LoadVolume() 
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume", volumeSlider.value);
    }
//QUALITY SETTINGS
    public void SetQuality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
//FULLSCREEN
    public void SetFullscreen(bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
    }

//RESOLUTION SETTINGS
    public void GetResolution() 
    {
        //clear the resolutions
        resolutions = Screen.resolutions;
        resolutiondropDown.ClearOptions();

        //create a list of options
        List<string> options = new List<string>();

        //set the list to be the lenght of the resolutions and create a string of resolutions
        int curResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                curResolutionIndex = i;
            }
        }

        resolutiondropDown.AddOptions(options);
        resolutiondropDown.value = curResolutionIndex;
        resolutiondropDown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
