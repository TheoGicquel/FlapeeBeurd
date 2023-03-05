using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class touchAction : MonoBehaviour
{
    public Vector2 speed;
    public GameObject player;

    public AudioClip playerFlapSound;


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
            AudioSource.PlayClipAtPoint(playerFlapSound, player.transform.position);

        }




        
          // for debug, prevent bird from going too far below
        /*if(player.transform.position.y < -20)
        {
            player.transform.position = new Vector3(player.transform.position.x, -20, player.transform.position.z);
        }
        */
        
        // get camera top right corner position
        Vector2 topRightCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector2 bottomLeftCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        // get player height
        float playerHeight = player.GetComponent<SpriteRenderer>().bounds.size.y;
        // if player above corner y position, set player y position to corner y position minus player height
        if(player.transform.position.y > (topRightCameraBorder.y-playerHeight))
        {
            player.transform.position = new Vector3(player.transform.position.x, topRightCameraBorder.y - playerHeight, player.transform.position.z);

        }

        // if player below corner y position, set player y position to corner y position plus player height
        if(player.transform.position.y < (bottomLeftCameraBorder.y+playerHeight))
        {
            player.transform.position = new Vector3(player.transform.position.x, bottomLeftCameraBorder.y + playerHeight, player.transform.position.z);

        }

      
    }
}
