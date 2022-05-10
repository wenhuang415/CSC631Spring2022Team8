using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    protected Animator myAnimation;
    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        myAnimation.SetFloat("Speed", Input.GetAxis("Vertical"));

    }
}
