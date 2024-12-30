using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorMansion : MonoBehaviour
{
    public float theDistance;

    public AudioSource doorOpenSound;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject door;
    public GameObject extraCross;
    public GameObject doorTrigger; 
    public GameObject fadeOut;
    public GameObject loadingText;

    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;

        if (GlobalInventory.isGrabbed == true) {
            doorTrigger.SetActive(true);
            StartCoroutine(LeaveMansion());
        }
    }

    IEnumerator LeaveMansion() 
    {
        fadeOut.SetActive(true);
        doorOpenSound.Play();

        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        SceneManager.LoadScene(6);
        GlobalAmmo.LoadAmmo();
        GlobalHealth.LoadHealth();
    }
}
