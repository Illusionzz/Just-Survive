using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject hurtFlash;

    public float enemySpeed = 0.002f;
    public bool attackingTrigger = false;
    public bool isAttacking = false;

    public AudioSource hurt1;
    public AudioSource hurt2;
    public AudioSource hurt3;
    public int hurtGen;
    
    void Update()
    {
        transform.LookAt(player.transform);
        if (attackingTrigger == false) {
            enemySpeed = 0.002f;
            enemy.GetComponent<Animation>().Play("Z_Walk_InPlace");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
        }
        if (attackingTrigger == true && isAttacking == false) {
            enemySpeed = 0;
            enemy.GetComponent<Animation>().Play("Z_Attack");
            StartCoroutine(DamagePlayer());
        }
    }

    void OnTriggerEnter()
    {
        attackingTrigger = true;
    }

    void OnTriggerExit()
    {
        attackingTrigger = false;
    }

    IEnumerator DamagePlayer() 
    {
        isAttacking = true;
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
            hurt1.Play();
        if (hurtGen == 2)
            hurt2.Play();
        if (hurtGen == 3)
            hurt3.Play();
        
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hurtFlash.SetActive(false);

        yield return new WaitForSeconds(1.1f);
        GlobalHealth.curHealth -= 5;

        yield return new WaitForSeconds(0.9f);
        isAttacking = false;
    }
}
