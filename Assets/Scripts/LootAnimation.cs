using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAnimation : MonoBehaviour
{

    public Vector3 originalPosition;
    public Vector3 vector;
    public float rotateSpeed;

    public bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition=transform.position;
        rotateSpeed=0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<=originalPosition.y-0.30f){
            goingUp=true;
        }
        if(transform.position.y>=originalPosition.y+0.30f){
            goingUp=false;
        }
        if(goingUp){
            vector = transform.position;
            vector.y +=.0010f;
            transform.position=vector;
        }
        if(!goingUp){
            vector = transform.position;
            vector.y -=.0010f;
            transform.position=vector;
        }
        transform.Rotate(Vector3.up,rotateSpeed,Space.World);
        
    }
}
