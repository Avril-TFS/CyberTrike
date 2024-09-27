using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    public enum HazardType{Door, Spike}
    public HazardType hazardType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if(hazardType == HazardType.Door)
            {
                PlayerController playerController = col.GetComponent<PlayerController>();
                if(playerController != null)
                {
                    playerController.GameOver();
                }
            }
        }
    }
}
