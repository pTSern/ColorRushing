using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 2, -8);
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    [Range(0, 1f)] private float smoothTime = 0.3f;

    private void LateUpdate()
    {
        // update position
        var targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
