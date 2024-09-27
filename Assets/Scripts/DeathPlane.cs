using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public Transform respawnPoint;
    
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            PlayerController playerController = col.GetComponent<PlayerController>();
            if(respawnPoint != null)
            {
                col.transform.position = respawnPoint.position;
                col.attachedRigidbody.velocity = Vector3.zero;
            }
        }
    }
}
