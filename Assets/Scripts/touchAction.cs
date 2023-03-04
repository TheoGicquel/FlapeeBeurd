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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed.x, speed.y);
        }

        // for debug, prevent bird from going too far below
        if(player.transform.position.y < -5)
        {
            player.transform.position = new Vector3(player.transform.position.x, -5, player.transform.position.z);
        }
    }
}
