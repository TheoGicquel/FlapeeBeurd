using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class clickButton : MonoBehaviour {
    public void onClick(){
            gameState.Instance.resetScorePlayer();
            gameState.Instance.setIsAlive(true);
            SceneManager.LoadScene("scene3-game");

    }
}