using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideManagementBird : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D collider) { 
    if(collider.tag == "pipe"){ 
        Debug.Log (collider.name);
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
