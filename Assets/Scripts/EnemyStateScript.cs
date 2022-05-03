using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;
public class EnemyStateScript : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider slider;//hp ui
    public GameObject healthBarUI;
    public object bullet;
    public Animator animator;
<<<<<<< HEAD
    public bool isAlive;
=======

>>>>>>> UpdatedMain

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        isAlive = true;
        animator = GetComponent<Animator>();
        health = maxHealth;
        slider.value = CalculateHealth();
=======
        animator = GetComponent<Animator>();
        health = maxHealth;
        slider.value = CalculateHealth();
        animator.Play("spawn");
>>>>>>> UpdatedMain
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
<<<<<<< HEAD
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        //Debug.Log("health:"+ health);
        //Debug.Log(isAlive);
        if (isAlive)
        {
            if (health <= 0.0f)
            {
                //Debug.Log("Zombie is dead");
                //animator.Play("death");//despawn dead bodies at the end of round in game state manager
                death();
            }
        }
    }

    void death()
    {
        isAlive = false;
        animator.SetTrigger("dead");
        Debug.Log("zombie is dead");
       //animator.Play("death");
=======
        if(health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
>>>>>>> UpdatedMain
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
