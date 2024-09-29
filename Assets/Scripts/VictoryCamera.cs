using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCamera : MonoBehaviour
{
    // Originally I was going to make the camera rotate, but decided to make the background scroll instead
    // I did find this code online, google is great help

    public float scrollSpeed = 0.01f;
    private Renderer bgRenderer;

    void Start()
    {
        bgRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        bgRenderer.material.mainTextureOffset = new Vector3(offset, 0, 0);
    }
}
