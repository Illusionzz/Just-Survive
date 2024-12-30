using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public float theDistance;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject fadeOut;
    public GameObject extraCross;
    
    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2) {
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
            extraCross.SetActive(true);
            actionText.GetComponent<Text>().text = "Open Door";
        }
        if (Input.GetButtonDown("Action"))
            if (theDistance <= 2) {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                fadeOut.SetActive(true);
                StartCoroutine(FadeOut());
            }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator FadeOut() 
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
        GlobalAmmo.LoadAmmo();
        GlobalHealth.LoadHealth();
    }
}
