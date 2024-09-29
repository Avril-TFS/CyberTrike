using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBoxes : MonoBehaviour
{
    public enum BoxRank { one, two, three, four }
    public BoxRank boxRank;

    public float speedToBreakOne = 15.0f;
    public float speedToBreakTwo = 20.0f;
    public float speedToBreakThree = 25.0f;
    public float speedToBreakFour = 30.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = col.gameObject.GetComponent<PlayerController>();

            float playerSpeed = playerController.PlayerSpeed();
            CheckIfBreakable(playerSpeed);
        }
    }

    void CheckIfBreakable(float playerSpeed)
    {
        float speedToBreak = GetSpeedRequired();

        if (playerSpeed >= speedToBreak)
        {
            BreakBox();
        }
    }
    void BreakBox()
    {
        Destroy(gameObject);
    }

    float GetSpeedRequired()
    {
        switch (boxRank)
        {
            case BoxRank.one:
                return speedToBreakOne;
            case BoxRank.two:
                return speedToBreakTwo;
            case BoxRank.three:
                return speedToBreakThree;
            case BoxRank.four:
                return speedToBreakFour;
            default:
                return float.MaxValue;
        }
    }


}
