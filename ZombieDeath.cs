using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour {

    public int enemyHealth = 20;
    public int StatusCheck;

    public GameObject enemy;

    void DamageZombie (int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    void Update () {
		if (enemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            enemy.GetComponent<Animation>().Stop("Z_Walk");
            enemy.GetComponent<Animation>().Play("Z_FallingBack");
        }
	}
}
