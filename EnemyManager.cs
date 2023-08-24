using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;

    public int score = 0;
    public Text ScoreBarText;

    private AudioSource source;

    public void Hit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameManager.enemiesAlive--;
            //Destroys Enemy Player i.e. Zombie
            Destroy(gameObject);

            ScoreManager.inst.IncrementScore();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
            source.Play();
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
            
        }
    }
}
