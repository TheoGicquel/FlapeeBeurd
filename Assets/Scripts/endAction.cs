using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
• will destroy the touchAction script to avoid all user interactions 
• will rotate, in a loop, the bird 
• will test if the bird is exiting the screen area 
• will launch the End scene
**/
public class endAction : MonoBehaviour
{

    public GameObject player;
    public AudioClip playerDeathSound;
    public AudioClip smashSound;

    public void killBird()
    {
      


        // play sound once 
        if(gameState.Instance.getIsAlive() == true)
        {

            // destroy touchAction script
            Destroy(player.GetComponent<touchAction>());
            // rotate bird by applying torque
            player.GetComponent<Rigidbody2D>().AddTorque(500);

            // trigger animation 
            //player.GetComponent<Animator>().SetTrigger("birdDying");
                AudioSource.PlayClipAtPoint(smashSound, player.transform.position);
                AudioSource.PlayClipAtPoint(playerDeathSound, player.transform.position);
                gameState.Instance.setIsAlive(false);

        }



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // used for debug, calls killBird() when 'k' is pressed
        /*
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K pressed");
            killBird();
        }
        */

                // test if bird is exiting screen area
        if(player.transform.position.y < -10)
        {
            Debug.Log("bird is exiting screen area");
            SceneManager.LoadScene("scene4-gameover");
        }

    }
}
