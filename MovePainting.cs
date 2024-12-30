using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePainting : MonoBehaviour
{
    public float theDistance;
    public bool triedToOpen = false;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject painting;
    public GameObject wall;
    public GameObject extraCross;

    public AudioSource wallMovingSound;

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
            triedToOpen = true;

            if (Input.GetButtonDown("Action") && triedToOpen == true) {
                StartCoroutine(SecretDoor());
            }
        }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator SecretDoor() 
    {
        painting.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(1.5f);
        wall.GetComponent<Animation>().Play();
        wallMovingSound.Play();
    }
}
