using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    public enum HazardType { Door, Spike, DeathPlane }     // This lets you select the type of hazard the gameObject is through the inspector in unity
    public HazardType hazardType;           // That way we can have a variety of types while keeping them on one script
    public Transform respawnPoint;          // this allows us to set a respawn location in unity. I made an empty game object, named RespawnPoint
                                            // its located where we want the player to return to and assigned it to the script in the inspector 


    // When the player collides with a hazard this will be called
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))   // this checks the tag of the object that collides with the game object this script is attached to
        {                               // it is searching specifical for the tag Player, and will only call the rest of the method if the player collides with it

            if (hazardType == HazardType.Door)      // everything within this if statement will only be called for an interaction with the Door 
            {
                PlayerController playerController = col.GetComponent<PlayerController>();       // This is telling the script to read the PlayerController.cs
                if (playerController != null)   // This basically just checks to see if the PlayerController.cs exists, if it doesn't nothing will happen
                {
                    playerController.GameOver();        // This calls the GameOver() Method located in PlayerController.cs
                }
            }

            if (hazardType == HazardType.DeathPlane)    // everything within this if statement will only be called for an interaction with the "Death PLane" 
            {                                           // The deathplane is an invisible collider under the stage so the player will die/reset instead of falling forever
                PlayerController playerController = col.GetComponent<PlayerController>();
                if (respawnPoint != null)
                {
                    col.transform.position = respawnPoint.position;     // This changes the players position to the preset respawn position
                    col.attachedRigidbody.velocity = Vector3.zero;      // this sets the players movement speed to 0 as a way to try and make respawning less unruly
                }
            }
        }
    }
}
