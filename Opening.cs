using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public GameObject player;
    public GameObject fadeIn;
    public GameObject textBox;

    public AudioSource line1;
    public AudioSource line2;
    
    void Start()
    {
        player.GetComponent<FirstPersonController>().enabled = false;

        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer() 
    {
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        textBox.GetComponent<Text>().text = "Uhhh. Where am I?";
        line1.Play();

        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "I needa get out of here.";
        line2.Play();

        yield return new WaitForSeconds(1.7f);
        textBox.GetComponent<Text>().text = "";
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}
