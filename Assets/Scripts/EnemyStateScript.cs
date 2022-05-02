using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateScript : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider slider;//hp ui
    public GameObject healthBarUI;
    public object bullet;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Touched " +collisionInfo.collider.name);
        //TODO Tag all bullets/damage sources and "Bullet"
        if(collisionInfo.collider.tag=="Bullet"){
            health--;//reduce health by one for each hit for now
            //health-=collisionInfo.collider.damage;//need a reference to the damage values, maybe a different tag for each weapon? or a matrix with damage values and tags?
        }

    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
