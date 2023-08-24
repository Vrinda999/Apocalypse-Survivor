using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int enemiesAlive = 0;
    public int round = 0;

    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    public Text roundNumber;
    public Text RoundsSurvived;
    public GameObject endScreen;
    public GameObject credits;

    private AudioSource zentry;

    // Start is called before the first frame update
    void Start()
    {
        zentry = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundNumber.text="Round: " + round.ToString();
        }
    }

    public void NextWave(int round)
    {
        for (var x = 0; x < round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();

            enemiesAlive++;
            zentry.Play();

        }

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMM()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        RoundsSurvived.text = round.ToString();
    }
}
