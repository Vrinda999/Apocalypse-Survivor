using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
    public static ScoreManager inst;
    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    public void IncrementScore()
    {
        score = score + 10;
        scoreText.text = "Score: " + score;

    }

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
