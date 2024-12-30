using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerOpen : MonoBehaviour
{
    public float theDistance;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject drawer;
    public GameObject extraCross;
    public GameObject drawerTrigger;
    public GameObject key;
    public GameObject textBox;

    public AudioSource drawerOpenSound;
    public AudioSource keyPickupSound;
    public AudioSource keyLine;
    
    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 1) {
            actionText.GetComponent<Text>().text = "Open Drawer";
            extraCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
            StartCoroutine(DrawerOpenAnim());
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator DrawerOpenAnim() 
    {
        this.GetComponent<BoxCollider>().enabled = false;
        actionDisplay.SetActive(false);
        actionText.SetActive(false);

        drawer.GetComponent<Animation>().Play("DrawerOpen");
        drawerOpenSound.Play();

        yield return new WaitForSeconds(0.6f);
        drawerOpenSound.Stop();
        drawerTrigger.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(1.5f);
        key.SetActive(false);
        GlobalInventory.isGrabbed = true;
        keyPickupSound.Play();
        keyLine.Play();
        textBox.GetComponent<Text>().text = "Better take this key with me.";

        yield return new WaitForSeconds(0.2f);
        keyPickupSound.Stop();

        yield return new WaitForSeconds(1.2f);
        textBox.GetComponent<Text>().text = "";
    }
}
