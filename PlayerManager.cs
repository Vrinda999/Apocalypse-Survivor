using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float Health = 100;
    public Text HealthBarText;

    public GameManager gameManager;

    public void Hit(float damage)
    {
        Health -= damage;
        HealthBarText.text = Health.ToString() + " HP";

        if (Health <= 0)
        {
            gameManager.EndGame();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
