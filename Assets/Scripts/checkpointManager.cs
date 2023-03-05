using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointManager : MonoBehaviour
{
    public GameObject player;
    public GameObject checkpoint;
    public GameObject upPipe;
    public GameObject downPipe;


    public void fitToPipes()
    {
               // get downpipe top left and top right position
        Vector3 downPipeTopLeft = downPipe.GetComponent<SpriteRenderer>().bounds.min;
        Vector3 downPipeTopRight = downPipe.GetComponent<SpriteRenderer>().bounds.max;
        // get uppipe bottom left and bottom right position
        Vector3 upPipeBottomLeft = upPipe.GetComponent<SpriteRenderer>().bounds.min;
        Vector3 upPipeBottomRight = upPipe.GetComponent<SpriteRenderer>().bounds.max;
        // scale checkpoint to fit between pipes
        checkpoint.transform.localScale = new Vector3(1, (upPipeBottomLeft.y - downPipeTopLeft.y), 1);

        // position checkpoint between pipes
       // checkpoint.transform.position = new Vector3(downPipeTopRight.x, (upPipeBottomLeft.y - downPipeTopLeft.y) / 2, 0);
    } 

    // Start is called before the first frame update
    void Start()
    {   
        
 
        
    }

    // Update is called once per frame
    void Update()
    {
        fitToPipes();
    }
}
