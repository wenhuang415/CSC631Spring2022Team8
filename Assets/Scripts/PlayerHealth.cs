using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = 10.0f;
        maxHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(float val){
        health -= val;
    }

    void TakeHealing(float val){
        health += val;
    }
}
