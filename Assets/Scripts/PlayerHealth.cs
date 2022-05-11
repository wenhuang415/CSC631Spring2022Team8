using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public float health;
    public float maxHealth;

    public bool isAlive;
    public GameStateScript script;

    // Start is called before the first frame update
    void Start()
    {
        health = 10.0f;
        maxHealth = health;
        script.numPlayersAlive++;
    }

    // Update is called once per frame
    void Update()
    {
        if(health<0 && isAlive){//death
            Vector3 vector = new Vector3(18f,22f,12.5f);
            teleport(vector);
            isAlive=false;
        }
        if((script.gameState==0) && !isAlive){//respawn
            respawn();
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Touched " + collisionInfo.collider.name);
        //TODO Tag all bullets/damage sources and "Bullet"
        if (collisionInfo.collider.tag == "Bullet")
        {
            TakeDamage(1);//reduce health by one for each hit for now
        }
        if (collisionInfo.collider.tag == "Health Pickup")
        {
            TakeHealing(1);//increase health by one for each hit for now
            Destroy(collisionInfo.gameObject);
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void TakeDamage(float val){
        health -= val;
    }

    void TakeHealing(float val){
        health += val;
    }
    
    void teleport(Vector3 vector){
        script.numPlayersAlive--;
        transform.position=vector;
    }

    void respawn(){
        script.numPlayersAlive++;
        health=maxHealth;
        isAlive=true;
        Vector3 vector = new Vector3(13f,6f,7f);
        teleport(vector);
    }
}
