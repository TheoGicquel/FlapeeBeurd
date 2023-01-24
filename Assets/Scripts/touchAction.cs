using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class touchAction : MonoBehaviour
{
    public Vector2 speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
     //speed = new Vector2(0, 5);   
    }

    // Update is called once per frame
    void Update()
    {
     // on spacebar input, apply up velocity to gameobject
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed.x, speed.y);
        }
    }
}
