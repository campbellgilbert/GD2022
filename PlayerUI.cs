using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public Text health;
    public Text maxJumps;

    Health playerStats;
    MenuController menuValues;

    //public string gameOverScene = "GameOver";

    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        SetStats();

        //send to GameOver scene
        //if (playerStats.health <= 0){
            //menuValues.isGameOver = true;
            //SceneManager.LoadScene(gameOverScene);
        //}
    }

    void SetStats(){
        //displays in the HUD based on info in PlayerMovement script
        health.text = "Health: " + playerStats.currentHealth;
        //maxJumps.text = "Max Jumps: " + playerStats.jumpsMax.ToString();
    }
}
