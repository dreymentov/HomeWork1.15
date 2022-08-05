using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;

    public Vector3 PlatformCameraOffset;

    public float Speed;

    // Update is called once per frame
    void Update()
    {
        if (player.currentPlatform == null) return;

        Vector3 targetPosition = player.currentPlatform.transform.position + PlatformCameraOffset;
        Speed = player.GetComponent<Rigidbody>().velocity.y;
        if(Speed <= 0)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, -Speed * Time.deltaTime);
    }
}
