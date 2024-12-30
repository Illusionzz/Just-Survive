using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioSource doorBang;
    public AudioSource jumpScareMusic;
    public AudioSource gameMusic;

    public GameObject zombie;
    public GameObject door;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Animation>().Play("JumpDoor");

        doorBang.Play();
        zombie.SetActive(true);
        StartCoroutine(JumpScareMusic());
    }

    IEnumerator JumpScareMusic() 
    {
        gameMusic.Pause();
        jumpScareMusic.Play();

        yield return new WaitForSeconds(4.5f);

        gameMusic.Play();
    }
}
