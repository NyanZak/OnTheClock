using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuButtons, SettingsButtons, LevelSelectButtons, Title;
    public Animator _SlidingAnimator;
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LevelSelect()
    {
        MainMenuButtons.SetActive(false);
        LevelSelectButtons.SetActive(true);
    }
    public void Settings()
    {
        _SlidingAnimator.SetBool("MoveRight", true);
        Title.SetActive(false);
        StartCoroutine(Delay());   
    }
    public void Return()
    {
        MainMenuButtons.SetActive(true);
        LevelSelectButtons.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator Delay()
    {
        MainMenuButtons.SetActive(false);
        yield return new WaitForSeconds(1);
        SettingsButtons.SetActive(true);
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
}
