using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class ArrowTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject textBox;
    public GameObject goldArrow;

    public AudioSource line3;

    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer() 
    {
        textBox.GetComponent<Text>().text = "Is that a... pistol on the table?";
        line3.Play();
        yield return new WaitForSeconds(2.5f);

        textBox.GetComponent<Text>().text = "";
        player.GetComponent<FirstPersonController>().enabled = true;
        goldArrow.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
