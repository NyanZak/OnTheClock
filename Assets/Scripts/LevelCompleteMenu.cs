using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCompleteMenu : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource ButtonPress;
    float originalVolume;
    private void Start()
    {
        backgroundMusic.volume = 0.5f * originalVolume;
        Time.timeScale = 0f;
    }
    public void NextLevel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        backgroundMusic.volume = originalVolume;
        SceneManager.LoadScene("Level2");
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
