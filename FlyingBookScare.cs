using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingBookScare : MonoBehaviour
{
    public GameObject book;
    public GameObject textBox;

    public AudioSource throwSound;
    public AudioSource bookVoiceLine;

    void Start()
    {
        StartCoroutine(BookThrow());
    }

    IEnumerator BookThrow() 
    {
        yield return new WaitForSeconds(5);
        book.GetComponent<Animation>().Play();
        throwSound.Play();

        yield return new WaitForSeconds(1.5f);
        bookVoiceLine.Play();
        textBox.GetComponent<Text>().text = "What the... What was that?";

        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "";
    }
}
