using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public AudioSource backgroundMusic;
    public GameObject pauseManuUI;
    public AudioSource ButtonPress;
    float originalVolume;
    private void Start()
    {
        originalVolume = backgroundMusic.volume;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        ButtonPress.Play();
        pauseManuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        backgroundMusic.volume = originalVolume;
    }
    void Pause()
    {
        ButtonPress.Play();
        pauseManuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        backgroundMusic.volume = 0.5f * originalVolume;
        FindObjectOfType<AudioManager>().Play("Lost");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu"); 
    }
}
