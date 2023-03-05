using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class moveBk : MonoBehaviour
{

    private GameObject[] backgrounds;
    public float positionRestartX;
    public Vector2 movement;
    private Vector3 siz;
    private Vector3 leftBottomCameraBorder;
    private Vector3 rightBottomCameraBorder;
    private Vector3 leftTopCameraBorder;
    private Vector3 rightTopCameraBorder;
    private Canvas canvas; 
    private const float resetX = 0.0f;


    private void setupBackgrounds(GameObject[] backgroundObjects)
    {
        // move first backgournd to center 
        backgroundObjects[0].transform.position = new Vector3(0, 0, 0);
        // get name of first background
        string firstBackgroundName = backgroundObjects[0].name;
        Debug.Log("firstBackgroundName: " + firstBackgroundName);
        float scaling = 2.0f;
         float ypos = 0.0f;
         float width = backgroundObjects[0].GetComponent<SpriteRenderer>().bounds.size.x;

         float height = backgroundObjects[0].GetComponent<SpriteRenderer>().bounds.size.y;
        float beginPos = backgroundObjects[0].transform.position.x;
        Debug.Log("backgroundObjects[0].transform.position.x: " + backgroundObjects[0].transform.position.x);
        //Debug.Log("width: " + width);
        //Debug.Log("height: " + height);
        //Debug.Log("beginPos: " + beginPos);
        //Debug.Log("test with scaling : " + 2*width*scaling);

        float xposOffset = 0;
        // iterate
        int i = 2;
        foreach(GameObject background in backgroundObjects) 
        {
            // apply scaling to background
            background.transform.localScale = new Vector3(scaling, scaling, 1);
            background.transform.position = new Vector3(xposOffset, ypos, 0);
            xposOffset = xposOffset + width;   
            i++;

        }

        


    }

    // Start is called before the first frame update
    void Start()
    {
        // move self to center of screen
        transform.position = new Vector3(0, 0, 0);
        // setup camera borders
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));


        backgrounds = GameObject.FindGameObjectsWithTag("bk");
        setupBackgrounds(backgrounds);

        // get position of last background
        positionRestartX = backgrounds[backgrounds.Length - 1].transform.position.x;


    }



    void scrollBackground(GameObject background, Vector2 speed)
    {
        background.GetComponent<Rigidbody2D> ().velocity = new Vector2(speed.x, speed.y);
        siz.x = background.GetComponent<SpriteRenderer> ().bounds.size.x;
        siz.y = background.GetComponent<SpriteRenderer> ().bounds.size.y;
        const float borderTearOffset = 0.5f;

        // check if background is out of screent
        if(background.transform.position.x < leftBottomCameraBorder.x - (siz.x / 2)) 
        {
            // move background to the right
            
            background.transform.position = new Vector3(positionRestartX-borderTearOffset, background.transform.position.y, background.transform.position.z);
        }   
    }

    // Update is called once per frame
    /**
    *This is the Update method of the moveBk script.
    *The positonRestartX variable is public.
    *It is set with the transform.posi;on.x background3 value.
    **/
    void Update()
    {
        //GetComponent<Rigidbody2D>().velocity = movement;
        
    foreach(GameObject background in backgrounds) 
    {
        scrollBackground(background, new Vector2(-1, 0));
    }

        
    }
}
