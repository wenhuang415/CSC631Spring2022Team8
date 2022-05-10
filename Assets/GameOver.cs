using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Setup()
    {
        gameObject.SetActive(true);
    }
   public void RestartButton()
    {
        Debug.Log("RESTART CLICKED");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void QuitButton()
    {
        Debug.Log("QUIT CLICKED");
        SceneManager.LoadScene("Menu");
    }
}
