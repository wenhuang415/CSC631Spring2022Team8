using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{
    public int gameState;
    //0 for shop mode
    //1 for spawn mode

    public float shopTime;

    public Object Enemy;

    // Start is called before the first frame update
    void Start()
    {
        // gameState = 0;
        // shopTime = 30;//time in seconds
        Debug.Log("Shop is open for " + shopTime + "seconds" );
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 0)
        {
            shopTime = shopTime - Time.deltaTime;
            Debug.Log("Shop is open for " + shopTime + "seconds" );
            if (shopTime <= 0)
            {
                gameState = 1;
            }
        }
        else if (gameState == 1)
        {
            SpawnEnemies();
            gameState = 0;//just spawn 1 
            shopTime = 10;
        }
    }

    void SpawnEnemies()
    {
        Instantiate(Enemy, new Vector3(36,1,13), Quaternion.identity);
    }
}
