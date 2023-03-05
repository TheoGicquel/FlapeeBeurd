using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class gameState : MonoBehaviour
{
    public static gameState Instance;
    private int scorePlayer = 0;
    private bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance.gameObject);
        }
        else if (this != Instance)
        {
            Debug.Log("Detruit");
            Destroy(this.gameObject);
        }
        
        
    }

    public void addScorePlayer(int toAdd)
    {
        scorePlayer += toAdd;
    }

    public int getScorePlayer()
    {
        return scorePlayer;
    }

    public void resetScorePlayer()
    {
        scorePlayer = 0;
    }

    public void resetGame()
    {
        resetScorePlayer();
        setIsAlive(true);
    }


    public void setIsAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    public bool getIsAlive()
    {
        return isAlive;
    }

    // Update is called once per frame
    void Update()
    {
        // find current scene 
        // if scene is scene2-menu, update score label
        if((SceneManager.GetActiveScene().name == "scene3-game") || (SceneManager.GetActiveScene().name == "scene4-gameover"))
        {
            GameObject.FindWithTag ("scoreLabel").GetComponent<Text>().text = "" + scorePlayer; 
        }
    }


}


