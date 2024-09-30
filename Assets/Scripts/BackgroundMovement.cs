using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public Transform player;
    public float parallaxSpeed = 0.02f;

    private Renderer bgRenderer;
    private Vector3 prevPlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        bgRenderer = GetComponent<Renderer>();
        prevPlayerPos = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        float playerMovement = player.position.x - prevPlayerPos.x;

        if (playerMovement != 0)
        {
            float offset = bgRenderer.material.mainTextureOffset.x + (playerMovement * parallaxSpeed);
            bgRenderer.material.mainTextureOffset = new Vector3(offset, 0, 0);
        }

        prevPlayerPos = player.position;
    }
}
