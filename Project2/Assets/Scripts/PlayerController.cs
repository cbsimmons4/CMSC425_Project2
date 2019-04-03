using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Text text;
    public Text objective; //Just felt like adding ojective text.
    public GameObject key;
    public GameObject chest;
    bool gameOn;
    bool paused;
    Rigidbody m_Rigidbody;
    int task;
    private void Start()
    {
        Time.timeScale = 1;
        gameOn = true;
        paused = false;
        m_Rigidbody = GetComponent<Rigidbody>();
        objective.text = "Objective: Get the key from the boat.";
        task = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            QuitGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameOn)
            {
                if (!paused)
                {
                    text.color = Color.black;
                    text.text = "paused";
                    Time.timeScale = 0;
                }
                else
                {
                    text.text = "";
                    Time.timeScale = 1;
                }
                paused = !paused;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crab")) {
            if (gameOn) 
            {
                text.color = Color.red;
                text.text = "You Lose!";
                gameOn = false;
                Time.timeScale = 0;
            }
        }

        if (other.CompareTag("Key"))
        {
            if (gameOn && task == 0)
            {
                objective.text = "Objective: Collect the chest.";
                task++;
                key.SetActive(false);
            
            }
        }

        if (other.CompareTag("Chest"))
        {
            if (gameOn && task == 1)
            {
                objective.text = "Objective: Return to the home island.";
                task++;
                chest.SetActive(false);
            }
        }

        if (other.CompareTag("Home"))
        {
            if (gameOn && task == 2)
            {
                objective.text = "";
                task++;
                text.color = Color.green;
                text.text = "You Win!";
                gameOn = false;
                Time.timeScale = 0;
            }
        }
    }

    // Taken from https://answers.unity.com/questions/899037/applicationquit-not-working-1.html
    public void QuitGame()
    {
        // save any game data here
    #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
    #endif
    }

}
