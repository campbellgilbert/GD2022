using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public string mainMenuScene;
    public string level1Scene; //since roguelike, start from beginning not save point
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMain(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene); //make main menu ui
    }
    public void QuitGame(){
        Application.Quit(); //built in quit
    }

    public void TryAgain(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(level1Scene);
        
    }
}
