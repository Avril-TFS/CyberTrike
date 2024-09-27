using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum PowerUpType{SpeedBoost, AddTime}
    public PowerUpType powerUpType;

    public float rotationSpeed = 10.0f;
    public float speedIncrease = 5.0f;
    public int timeIncrease = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            Destroy(gameObject);

            if(powerUpType == PowerUpType.SpeedBoost)
            {
                PlayerController playerController = col.GetComponent<PlayerController>();
                if(playerController != null)
                {
                    playerController.SpeedBoost(speedIncrease);
                }
            }
            else if( powerUpType == PowerUpType.AddTime)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                if(gameManager != null)
                {
                    gameManager.AddTime(timeIncrease);
                }
            }
        }
    }
}
