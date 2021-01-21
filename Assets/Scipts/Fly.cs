using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    //amount of fly force applied on click
    public Vector2 FlyForce;
    //collision detection
    bool col = true;


    // Update is called once per frame
    void Update()
    {     
        //Disables fly() if bird flies of screen 
        if(transform.position.y > 5.35 || transform.position.y < - 5.54)
            col = false;

         fly();       
    }   

    //Method to fly and play fly audio if fire button pressed and character
    //has not collided with an object  
    void fly(){        
        if(Input.GetButtonDown("Fire1") && col){
            GetComponent<Rigidbody2D>().AddForce(FlyForce);
            GetComponent<AudioSource>().Play();
        }   
    }

    //Disables fly() if character collides with an object
    void OnCollisionEnter2D(Collision2D collision){        
        col = false;
    }
    

}
