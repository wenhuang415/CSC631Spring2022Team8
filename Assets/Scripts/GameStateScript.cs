using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{
    public int gameState;
    //0 for shop mode
    //1 for spawn mode

    public float shopTime;

    public int numEnemiesToSpawn=5;

    public int numEnemiesSpawned=0;

    public int numEnemiesDefeated=0;

    public Object Enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        // gameState = 0;
        // shopTime = 30;//time in seconds
        Debug.Log("Shop is open for " + shopTime + " seconds" );
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 0)//Time to shop!
        {
            shopTime = shopTime - Time.deltaTime;
            //Debug.Log("Shop is open for " + shopTime + "seconds" );
            // Debug.Log("Shop is open");
            if (shopTime <= 0)
            {
                gameState = 1;
                Debug.Log("gamestate: "+gameState);
            }
        }
        if (gameState == 1)//Time to Fight!
        {
            if(numEnemiesSpawned!=numEnemiesToSpawn){
                for(numEnemiesSpawned = 0;numEnemiesSpawned < numEnemiesToSpawn; numEnemiesSpawned++){
                    
                    //Debug.Log("Spawning enemy # "+numEnemiesSpawned);
                    SpawnEnemy();
                }
            }
            
            if(numEnemiesDefeated==numEnemiesToSpawn){
                gameState = 0;
                shopTime = 5;//reset shop time. TEST VALUE
                //shopTime = 30;//reset shop time.
                numEnemiesToSpawn+=5;//add more enemies
                numEnemiesDefeated=0;//reset kill count
                numEnemiesSpawned=0;//reset spawn count
                Debug.Log("Shop is open");
            }
        }

    }

    void SpawnEnemy()
    {

        int spawnLocation=Random.Range(0,4);//each int represents a different location
        Vector3 vector = new Vector3(0,0,0);

        switch(spawnLocation){
            case 0:
                 vector = new Vector3(Random.Range(38f,42f),1,Random.Range(11f,14f));
                break;
            case 1:
                 vector = new Vector3(Random.Range(10f,14f),1,Random.Range(-6f,-9f));
                break;
            case 2:
                 vector = new Vector3(Random.Range(10f,14f),1,Random.Range(25f,28f));
                break;
            case 3:
                 vector = new Vector3(Random.Range(-8f,-5f),1,Random.Range(5f,9f));
                break;
            default:
                break;

        }
        //Debug.Log("Spawning at location " + spawnLocation);
        Instantiate(Enemy, vector, Quaternion.identity);
    }
}
