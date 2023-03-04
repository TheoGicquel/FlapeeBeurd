using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePipes : MonoBehaviour
{
    public Vector2 movement;
    public GameObject pipe1Up;
    public GameObject pipe1Down;
    public int itercount = 0;
    // private
    private Transform pipe1UpOriginalTransform;
    private Transform pipe1DownOriginalTransform;
    private Vector2 pipeSize;
    private Vector2 leftBottomCameraBorder;
    private Vector2 rightBottomCameraBorder;

    public bool verbose;

    public void log(string msg)
    {
        if (verbose)
        {
            Debug.Log(msg);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

        pipe1UpOriginalTransform = pipe1Up.transform;
        pipe1DownOriginalTransform = pipe1Down.transform;
        log("pipe1UpOriginalTransform: " + pipe1UpOriginalTransform.position);



    }

    // Update is called once per frame
    void Update()
    {
        pipe1Up.GetComponent<Rigidbody2D>().velocity = movement; // Déplacement du pipe haut 
        pipe1Down.GetComponent<Rigidbody2D>().velocity = movement; // Déplacement du pipe bas 
        pipeSize.x = pipe1Up.GetComponent<SpriteRenderer> ().bounds.size.x; // Récuperation de la taille d’un pipe  
        pipeSize.y = pipe1Up.GetComponent<SpriteRenderer> ().bounds.size.y; // Suffisant car ils ont la même taille
       
        // Le pipe est sorti de l’écran ? Si oui appel de la méthode moveTORightPipe
        if (pipe1Up.transform.position.x < leftBottomCameraBorder.x - (pipeSize.x / 2))
        {
            moveToRightPipe();
        }

  
        
        
    }


    void moveToRightPipe()
    {

        itercount++;
        log("-- moveToRightPipe " + itercount + " --");
        log("pipe1Up.transform.position: " + pipe1Up.transform.position); 
        float randomY =	Random.Range (1,4) - 2; // Tirage aléatoire d’un décalage en Y 
        
        
        float posX = rightBottomCameraBorder.x + (pipeSize.x / 2); // Calcul du X du bord droite de l’écran
        
        // Calcul du nouvel Y en reprenant la position Y d’origine du pipe, ici le downPipe1 
        float posY = pipe1UpOriginalTransform.position.y + randomY; 
        
        
        // Création du vector3 contenant la nouvelle position 
        Vector3 tmpPos = new Vector3 (posX, posY, pipe1Up.transform.position.z); 
        // Affectation de cette nouvelle position au transform du gameObject
        pipe1Up.transform.position = tmpPos; 
        
        // Idem pour le second pipe 
        posY = pipe1DownOriginalTransform.position.y + randomY; 
        
        tmpPos = new Vector3 (posX,posY, pipe1Down.transform.position.z); 
        pipe1Down.transform.position = tmpPos;
        log("pipe1Up.transform.position: " + pipe1Up.transform.position); 
        log("----------------" + itercount + "---------------");

    }
}
