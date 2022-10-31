using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string mainMenuScene;
    public string level1Scene; //since roguelike, start from beginning not save point
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public bool isPaused = false;
    public bool isGameOver = false;
    public Health health;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        //health = GetComponent<Health>();
        //PlayerUI playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //esc key
        //timescale 0 stops in game time and 1 put back to normal.
        if(Input.GetKeyDown(KeyCode.Escape) && isGameOver == false){
            if (isPaused) {
                ResumeGame();
            }
            else {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        } else {
            isPaused = false;
        }

        //how to reference health

        
        //Debug.Log(health.currentHealth);
        if (health.currentHealth <= 0){
            isGameOver = true;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void ResumeGame(){
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMain(){
        Time.timeScale = 1f;
        //isGameOver = false;
        //gameOverScreen.SetActive(false);
        SceneManager.LoadScene(mainMenuScene); //make main menu ui
    }
    public void QuitGame(){
        //isGameOver = false;
        Application.Quit(); //built in quit
    }

    public void TryAgain(){
        Time.timeScale = 1f;
        //gameOverScreen.SetActive(false);
        SceneManager.LoadScene(level1Scene);
        
    }

}