using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Slider MusicSlider;
    public Slider GameSlider;
    public AudioMixer GameMixer;
    public AudioMixer MusicMixer;
    public Toggle fullscreen;
    Resolution[] resolutions;

    void Awake()
    {
        //Seting up every option
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionW"), PlayerPrefs.GetInt("ResolutionH"), PlayerPrefs.GetInt("isfull")==1?true:false);
        GameMixer.SetFloat("Volume", PlayerPrefs.GetFloat("GameVolume"));
        MusicMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MusicVolume"));

        //Seting up every visual option
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        GameSlider.value = PlayerPrefs.GetFloat("GameVolume");
        fullscreen.isOn = PlayerPrefs.GetInt("isfull")==1?true:false;
    }

    private void Start() 
    {
        //Resolution DropDown Stuff
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex");
        resolutionDropdown.RefreshShownValue();
    }

    public void SetFullScreen(bool isfull)
    {
        PlayerPrefs.SetInt("isfull", isfull?1:0);
        Screen.fullScreen = isfull;
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("GameVolume", volume);
        GameMixer.SetFloat("Volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        MusicMixer.SetFloat("Volume", volume);
    }

    public void SetScreenResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        PlayerPrefs.SetInt("ResolutionIndex", resIndex);
        PlayerPrefs.SetInt("ResolutionW", resolution.width);
        PlayerPrefs.SetInt("ResolutionH", resolution.height);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
