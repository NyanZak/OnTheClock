using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Animator _SlidingAnimator;
    public GameObject MainMenuButtons, SettingsButtons, Title, AudioSettings, GraphicsSettings;
    public AudioMixer audioMixerSFX, audioMixerMusic;
    public Slider SfxSlider, MusicSlider;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("MusicSlider", MusicSlider.value);
        SfxSlider.value = PlayerPrefs.GetFloat("SFXSlider", SfxSlider.value);
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void Audio()
    {
        AudioSettings.SetActive(true);
        GraphicsSettings.SetActive(false);
    }
    public void Graphics()
    {
        AudioSettings.SetActive(false);
        GraphicsSettings.SetActive(true);
    }
    public void Return()
    {
        AudioSettings.SetActive(false);
        GraphicsSettings.SetActive(false);
        _SlidingAnimator.SetBool("MoveRight", false);
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        SettingsButtons.SetActive(false);
        yield return new WaitForSeconds(1);
        MainMenuButtons.SetActive(true);
        Title.SetActive(true);
    }
    public void SetVolumeMusic(float volume)
    {
        audioMixerMusic.SetFloat("MusicVol", volume);
        //Mathf.Log10(volume) * 20);
    }
    public void MusicSlide()
    {
        PlayerPrefs.SetFloat("MusicSlider", MusicSlider.value);
    }
    public void SetVolumeSFX(float volume)
    {
        audioMixerSFX.SetFloat("SFXVol", volume);
            //Mathf.Log10(volume) * 20);
    }
    public void SfxSlide()
    {
        PlayerPrefs.SetFloat("SFXSlider", SfxSlider.value);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen");
    }
}