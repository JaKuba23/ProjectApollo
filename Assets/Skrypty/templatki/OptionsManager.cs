using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public GameObject wrocRend;
    public GameObject wyjdzRend;
    public Sprite[] wyjdz;
    public Sprite[] wroc;
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
    public static bool once = true;

    void Awake()
    {
        effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        //Seting up every option
        Screen.SetResolution(PlayerPrefs.GetInt("ResolutionW"), PlayerPrefs.GetInt("ResolutionH"), PlayerPrefs.GetInt("isfull")==1?true:false);

        //Seting up every visual option
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume")*2;
        GameSlider.value = PlayerPrefs.GetFloat("GameVolume")*2;
        fullscreen.isOn = PlayerPrefs.GetInt("isfull")==1?true:false;
    }

    private void Start() 
    {
        wrocRend.GetComponent<Image>().sprite = wroc[0];
        wyjdzRend.GetComponent<Image>().sprite = wyjdz[0];
        GameMixer.SetFloat("Volume", PlayerPrefs.GetFloat("GameVolume")/2);
        MusicMixer.SetFloat("Volume", PlayerPrefs.GetFloat("MusicVolume")/2);
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

        if(once)
        {
            PlayerPrefs.SetInt("ResolutionIndex", currentResolutionIndex);
            once = false;
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
        PlayerPrefs.SetFloat("GameVolume", volume/2);
        GameMixer.SetFloat("Volume", volume/2);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume/2);
        MusicMixer.SetFloat("Volume", volume/2);
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

    public void WyjsciePointerEnter()
    {
        wyjdzRend.GetComponent<Image>().sprite = wyjdz[1];
    }

    public void WyjsciePointerExit()
    {
        wyjdzRend.GetComponent<Image>().sprite = wyjdz[0];
    }

    public void WrocPointerEnter()
    {
        wrocRend.GetComponent<Image>().sprite = wroc[1];
    }

    public void WrociePointerExit()
    {
        wrocRend.GetComponent<Image>().sprite = wroc[0];
    }
}
