using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eye1 : MonoBehaviour
{
    public float theDistance;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject eye;
    public GameObject textBox;

    public AudioSource eyePickup;

    [Header("VoiceLines")]
    public AudioSource eyeLine1;

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
            StartCoroutine(KeyPickUp());
            actionText.GetComponent<Text>().text = "";
        }    
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator KeyPickUp() 
    {
        eye.SetActive(false);
        eyePickup.Play();
        // eyeLine1.Play();
        textBox.GetComponent<Text>().text = "Hm? A piece of paper with an eye? Weird.";

        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "";
    }
}
