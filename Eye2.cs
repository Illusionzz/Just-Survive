using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eye2 : MonoBehaviour
{
    public float theDistance;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject eye;
    public GameObject textBox;

    public AudioSource eyePickup;

    [Header("VoiceLines")]
    public AudioSource eyeLine2;

    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2) {
            actionText.GetComponent<Text>().text = "Pickup Paper";
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
        eyeLine2.Play();
        textBox.GetComponent<Text>().text = "Another one? Looks like I better hang on to this.";

        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "";
    }
}
