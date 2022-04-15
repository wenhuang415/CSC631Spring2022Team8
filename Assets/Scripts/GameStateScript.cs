using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{
    public int gameState;
    //0 for shop mode
    //1 for spawn mode

    public float shopTime;

    public int EnemnyCount;

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
        if (gameState == 0)
        {
            shopTime = shopTime - Time.deltaTime;
            //Debug.Log("Shop is open for " + shopTime + "seconds" );
            if (shopTime <= 0)
            {
                gameState = 1;
            }
        }
        else if (gameState == 1)
        {
            for(int i = 0;i <EnemnyCount; i++){
                SpawnEnemies();
            }
            gameState = 0;//just spawn 1 
            shopTime = 10;//reset shop time
        }
    }

    void SpawnEnemies()
    {

        int spawnLocation=Random.Range(0,3);//each int represents a different location
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
        Debug.Log("Spawning at location " + spawnLocation);
        Instantiate(Enemy, vector, Quaternion.identity);
    }
}
