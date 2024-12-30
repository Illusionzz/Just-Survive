using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public static int curHealth = 100;
    public int health;
    public static int scene;

    void Update()
    {
        health = curHealth;
        if (curHealth == 0)
            SceneManager.LoadScene(7);

        if (!PlayerPrefs.HasKey("health")) {
            PlayerPrefs.SetInt("health", curHealth);
            LoadHealth();
        }
        else {
            LoadHealth();
        }
    }

    public static void SaveHealth() 
    {
        PlayerPrefs.SetInt("health", curHealth);
    }

    public static void LoadHealth() 
    {
        PlayerPrefs.GetInt("health", 100);
    }
}
