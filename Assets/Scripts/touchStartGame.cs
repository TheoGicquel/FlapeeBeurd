using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class touchStartGame : MonoBehaviour
{
   


    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            gameState.Instance.resetGame();
            SceneManager.LoadScene("scene2-menu");
           // SceneManager.LoadScene("scene3-game");

        }


      
    }
}
