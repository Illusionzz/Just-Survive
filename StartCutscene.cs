using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartCutscene : MonoBehaviour
{
    [Header("Rifle Stuff")]
    public GameObject dirtMoundTrigger;
    public GameObject dirtMound;

    [Header("UI")]
    public GameObject extraCross;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject textBox;

    public GameObject player;
    public GameObject timeline;
    public GameObject fadeOut;
    public GameObject loadingText;

    public AudioSource line1;
    public AudioSource line2;
    public AudioSource line3;

    public float theDistance;

    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2) {
            actionText.GetComponent<Text>().text = "???";
            extraCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action")) {
            if (theDistance <= 2) {
                dirtMoundTrigger.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                StartCoroutine(Cutscene());
            }
        }
    }

    IEnumerator Cutscene() 
    {
        timeline.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        AudioManager.instance.StartMusic();
        line1.Play();
        textBox.GetComponent<Text>().text = "Hm? What's this?";

        yield return new WaitForSeconds(4);
        line2.Play();
        textBox.GetComponent<Text>().text = "Looks like it works. Maybe.";

        yield return new WaitForSeconds(5.5f);
        line3.Play();
        textBox.GetComponent<Text>().text = "Holy Shi-?";
        
        yield return new WaitForSeconds(3.5f);
        fadeOut.SetActive(true);
        SceneManager.LoadScene(7);
        GlobalAmmo.LoadAmmo();
        GlobalHealth.LoadHealth();
    }
}
