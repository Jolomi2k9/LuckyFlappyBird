using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdKiller : MonoBehaviour
{
    
    //GameObject for background music
    public GameObject backMusic;    
    //GameObject for hit audio
    public GameObject hitaudio;
    //
    public GameObject birdLife;        
    //collision detection
    public bool hit = false;
    //signal if hit audio has already been played    
    public bool playedOnce = false;
    //number of seconds to delay a respawn
    public int respawnDelay = 2;
    //checks if player is dead
    public bool dead = false; 
    //
    public LivesCounter checkLife;
    //
    
       

    
    void Start(){
        //Finds the gameobject "Music" and save it has "backMusic"
        backMusic = GameObject.Find("Music");
        //Finds the gameobject "hitAudio" and save it has "hitaudio"
        hitaudio = GameObject.Find("hitAudio");
        //
        birdLife = GameObject.Find("Bird1");
        checkLife = birdLife.GetComponent<LivesCounter>();
        dead = checkLife.dead;
    }   
    
    // Update is called once per frame    
    void Update()
    {
        //if the character flies of screen, respawn at scene 1
        if(transform.position.y > 5.35 || transform.position.y < - 5.54){            
            //respawn after a delay 
            Invoke("Respawn", respawnDelay);
            //signal that the character flew of screen
            hit = true;            
        }
        //If hit or fly off screen, stop background music and play hit audio once
        if(hit && playedOnce == false){
            //Stops background music
            backMusic.GetComponent<AudioSource>().Stop();
            //Plays hit audio 
            hitaudio.GetComponent<AudioSource>().Play();
            //detuct a life
            checkLife.hitsTaken(1);
            //ensured audio is only played once
            playedOnce = true; 
        }        
    }

    //action to take when character collides with an object
    private void OnCollisionEnter2D(Collision2D collision){
        //detuct a life
        checkLife.hitsTaken(1);
        //respawn after a delay        
        Invoke("Respawn", respawnDelay);
        //signal that a collision occured
        hit = true;                             
    }

    //reset to the start of the scene
    void Respawn(){
         SceneManager.LoadScene(1);
    }

    
}
