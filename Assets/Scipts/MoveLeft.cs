using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    
    public float Speed = 1 ;

    // Update is called once per frame
    void Update()
    {   
        //Smooths out the speed at which the obstacles moves
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

        //repositions sprites to right of frame after they move left out of frame
        if(transform.position.x < - 17){
            transform.position += new Vector3(30, 0, 0);
            ShowRandomMountains();
        }
    }

    //Method to display random mountain sprites from MountainsUP game object
    private void ShowRandomMountains(){

        //generates random number between 0 and 3
        int index = UnityEngine.Random.Range(0,3);
        //get number of child obects
        int childCount = transform.childCount;

        //loop through the child elements of "MountainsUP" game object
        for(int i = 0; i < childCount; i++){

            Transform child = transform.GetChild(i);
            //evaluates if the random number matches the current child count
            bool shoulShow = index == i;
            //activate the selected game object if true
            child.gameObject.SetActive(shoulShow);
        }
    }

    private void OnEnable(){
        ShowRandomMountains();
    }
}
