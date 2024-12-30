using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCard : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;

    public GameObject titleCard;

    void Start()
    {
        StartCoroutine(ToMainMenu());
    }

    IEnumerator ToMainMenu() 
    {
        yield return new WaitForSeconds(3);
        AudioManager.instance.StopMusic();

        yield return new WaitForSeconds(1);
        titleCard.SetActive(false);
        text1.SetActive(true);
        text2.SetActive(true);

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }
}
