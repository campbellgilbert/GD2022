using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameScene; //make the first level

    public void NewGame(){
        SceneManager.LoadScene(newGameScene);
    }

    public void QuitGame(){
        Application.Quit(); //built in quit
    }
}
