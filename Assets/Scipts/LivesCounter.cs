using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{

    public GameObject[] hearts;

    
    //lfe counter
    private int life;
    //Checks if character still has lives left
    public bool dead = false;

    void Start(){
        //initialize the number of lives to the number of 
        //hearts[] elements
        life = hearts.Length;        
    }
   
    

    //Removes a heart when Bird1 takes a hit
    public void hitsTaken(int hit){    
        life -= hit;
        Destroy(hearts[life].gameObject);
        if(life < 1){
            dead = true;
        }        
    }

}
