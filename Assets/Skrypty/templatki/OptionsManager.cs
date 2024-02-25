using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    AudioSource effect;
    [SerializeField] AudioClip click;
    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider GameSlider;
    [SerializeField] AudioMixer GameMixer;
    [SerializeField] AudioMixer MusicMixer;
    [SerializeField] Toggle fullscreen;
    Resolution[] resolutions;
    [SerializeField] GameObject Panel;

    void Awake()
    {
        effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        //Seting up every option
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionW"), PlayerPrefs.GetInt("ResolutionH"), PlayerPrefs.GetInt("isfull")==1?true:false);

        //Seting up every visual option
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        GameSlider.value = PlayerPrefs.GetFloat("GameVolume");
        fullscreen.isOn = PlayerPrefs.GetInt("isfull")==1?true:false;
    }

    private void Start() 
    {
        GameMixer.SetFloat("Volume", PlayerPrefs.GetFloat("GameVolume"));
        MusicMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MusicVolume"));
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

    void Update()
    {
        //turning on and off the option panel when the button is clicked
        if(Input.GetButtonDown("Cancel"))
            Panel.SetActive(!Panel.activeSelf);
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

    public void Menu()
    {
        Przejscie.NextScene = "Menu";
        Przejscie.SceneLoad();
    }

    public void TurnPanel()
    {
        Panel.SetActive(!Panel.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Click()
    {
        effect.PlayOneShot(click);
    }
}
