using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public float theDistance;
    public bool triedToOpen = false;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject door;
    public GameObject extraCross;

    public AudioSource doorJiggleSound;

    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2) {
            actionText.GetComponent<Text>().text = "Open Door";
            extraCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
            triedToOpen = true;

            if (Input.GetButtonDown("Action") && triedToOpen == true) {
                actionText.GetComponent<Text>().text = "Door Locked";
                doorJiggleSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
