using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collideManagementBird : MonoBehaviour
{

    public AudioClip checkpointSound;


  void OnTriggerEnter2D(Collider2D collider) { 
    if(collider.tag == "pipe" && gameState.Instance.getIsAlive() == true){ 
        // change color of bird
        // call endAction script killbird
        GetComponent<endAction>().killBird();
    }


  } 

  // on exit to make sure player is further than the checkpoint
  void OnTriggerExit2D(Collider2D collider) {
    if(collider.tag == "checkpoint" && gameState.Instance.getIsAlive() == true){ 
        // change color of bird
        gameState.Instance.addScorePlayer(1);	
        AudioSource.PlayClipAtPoint(checkpointSound, collider.transform.position);

    }
  }



    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
