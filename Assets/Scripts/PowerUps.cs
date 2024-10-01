using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, AddTime, Vector }
    public PowerUpType powerUpType;

    //public float rotationSpeed = 10.0f;
    public float speedIncrease = 5.0f;
    public int timeIncrease = 5;

    public float hoverHeight = .2f;
    public float hoverSpeed = 1.5f;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //  Rotate();
        Hover();
    }

    //void Rotate()
    //{
    //   transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    //}
    void Hover()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);

            if (powerUpType == PowerUpType.SpeedBoost)
            {
                PlayerController playerController = col.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.SpeedBoost(speedIncrease);
                }
            }
            else if (powerUpType == PowerUpType.AddTime)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.AddTime(timeIncrease);
                }
            }
            else if (powerUpType == PowerUpType.Vector)
            {
                PlayerController playerController = col.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.SpeedBoost(speedIncrease * 5);
                }
            }
        }
    }
}
