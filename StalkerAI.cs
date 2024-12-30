using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerAI : MonoBehaviour
{
    public static bool isStalking = false;
    public int enemyHealth = 20;

    public int hurtGen;
    public int punchGen;

    private bool isRunning = false;
    public bool attackingTrigger = false;
    public bool isAttacking = false;

    public GameObject stalkerDest;
    public GameObject stalker;
    public GameObject door;
    public GameObject hurtFlash;
    public GameObject doorTrigger;

    public Vector3 toDoor;
    public Vector3 toJump;
    public Vector3 jumpAndLeave;

    [Header("Player Sounds")]
    public AudioSource hurt1;
    public AudioSource hurt2;
    public AudioSource hurt3;

    [Header("Zombie Sounds")]
    public AudioSource scream;
    public AudioSource running;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isStalking == false) {
            stalker.GetComponent<Animator>().Play("Idle");
        }
        else if (enemyHealth == 0) {
            StartCoroutine(Flee());
            Scream();
        }
        else {
            if (attackingTrigger == false) {
                Running();
            }
            if (attackingTrigger == true && isAttacking == false) {
                Attack();
            }
        }
    }

    void DamageZombie (int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    void OnTriggerEnter()
    {
        attackingTrigger = true;
    }

    void OnTriggerExit()
    {
        attackingTrigger = false;
    }

    void Running() 
    {
        running.Play();
        stalker.GetComponent<Animator>().Play("Run");
        agent.speed = 4;
        agent.SetDestination(stalkerDest.transform.position);
    }

    void Attack() 
    {
        punchGen = Random.Range(1, 3);
        if (punchGen == 1)
            stalker.GetComponent<Animator>().Play("Punch1");
        if (punchGen == 2)
            stalker.GetComponent<Animator>().Play("Punch2");
        agent.speed = 0;
        StartCoroutine(DamagePlayer());
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
        GlobalHealth.curHealth -= 20;

        yield return new WaitForSeconds(0.9f);
        isAttacking = false;
        isRunning = true;
    }

    IEnumerator Flee() 
    {
        agent.speed = 0;

        yield return new WaitForSeconds(2);
        agent.transform.position = new Vector3(200, 10, 200);
    }

    void Scream() 
    {
        stalker.GetComponent<Animator>().Play("Scream");
        scream.Play();
    }
}
