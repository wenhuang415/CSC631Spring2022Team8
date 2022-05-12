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
    public Animator animator;
    public bool isAlive;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject loot;

    public GameStateScript gameStateScript;
    public GameObject gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        animator = GetComponent<Animator>();
        health = maxHealth;
        slider.value = CalculateHealth();
        gameStateManager=GameObject.FindWithTag("Manager");
        gameStateScript=(GameStateScript)gameStateManager.GetComponent(typeof(GameStateScript));
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        //Debug.Log("health:"+ health);
        //Debug.Log(isAlive);
        if (isAlive)
        {
            //Debug.Log("health: " + health);
            if (health <= 0.0f)
            {
                //Debug.Log("Zombie is dead");
                //animator.Play("death");//despawn dead bodies at the end of round in game state manager
                death();
            }
        }
        else if(!isAlive&&(gameStateScript.gameState==0)){
            Destroy(gameObject);
        }
    }

    void death()
    {
        audioSource.PlayOneShot(audioClip);
        isAlive = false;
        animator.SetTrigger("dead");
        Debug.Log("zombie is dead");
        gameStateScript.AnotherOneBitesTheDust();
        spawnLoot();
        waiter();
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
    void spawnLoot(){
        
        Vector3 vector = transform.position;
        vector.y +=1.0f;

        int rand = Random.Range(0,1);
        switch (rand){
            case 0: 
                Instantiate(loot, vector, Quaternion.identity);
                break;
            default:
                break;

        }
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(4);
        animator.gameObject.GetComponent<Animator>().enabled = false;
    }
}
