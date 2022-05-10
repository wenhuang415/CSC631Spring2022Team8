using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameOver : MonoBehaviourPunCallbacks
{

    public void Setup()
    {
        gameObject.SetActive(true);
    }
   public void RestartButton()
    {
        Debug.Log("RESTART CLICKED");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PhotonNetwork.LoadLevel(1);//load scene 1
    }

   public void QuitButton()
    {
        Debug.Log("QUIT CLICKED");
        PhotonNetwork.LoadLevel(2);
    }

}
