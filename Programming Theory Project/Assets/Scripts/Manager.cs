using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour  //INHERITANCE
{
    // singleton design pattern
    public static Manager Instance { get; private set; }  //ENCAPSULATION, anyone can use the manager but only the manager can set itself

    private void Awake()  //INHERITED ABSTRACTION
    {
        // proper way to ensure single instance of singleton in C#/Unity
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        // manager needs to be able to manage in every scene
        DontDestroyOnLoad(this.gameObject);  //ABSTRACTION
    }

    // Update is called every frame;
    private void Update()  //INHERITED ABSTRACTION
    {
        // if we enter game over scene end the game and quit the application after a short delay
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))  //ABSTRACTION
            StartCoroutine(GameOver());  //ABSTRACITON
    }

    // start the game
    public void OnStartButtonClick()  //ABSTRACTION
    {
        SceneManager.LoadScene(1);  //ABSTRACTION
    }

    // end the game
    public void EndGame()  //ABSTRACTION used with INHERITANCE + POLYMORPHISM in Player : Character class
    {
        SceneManager.LoadScene(2);  //ABSTRACTION
    }

    // wait a bit so user can read game over screen and then quit application, could use future refinement
    IEnumerator GameOver()  //ABSTRACTION
    {
        yield return new WaitForSeconds(13);  //ABSTRACTION
        Debug.Log("Application Quit");
        Application.Quit();  //ABSTRACTION
    }
}
