using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadingText;

    public GameObject notYetPanel;
    public GameObject optionsPanel;

    public AudioSource buttonClick;

    public void NewGameButton() 
    {
        StartCoroutine(NewGameStart());
    }

    public void QuitGameButton() 
    {
        StartCoroutine(QuitButton());
    }

    public void OptionsButton() 
    {
        optionsPanel.SetActive(true);
    }

    public void BackButton() 
    {
        optionsPanel.SetActive(false);
    }

    public void NotYet() 
    {
        notYetPanel.SetActive(true);
    }

    public void OK() 
    {
        notYetPanel.SetActive(false);
    }

    IEnumerator NewGameStart() 
    {
        fadeOut.SetActive(true);
        buttonClick.Play();

        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        SceneManager.LoadScene(4);
    }

    IEnumerator QuitButton() 
    {
        fadeOut.SetActive(true);
        buttonClick.Play();

        yield return new WaitForSeconds(2.0f);
        Application.Quit();
    }
}
