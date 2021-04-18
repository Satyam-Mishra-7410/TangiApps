using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private Vector3 offset;

    private Vector3 targetPosition { get { return objectToFollow.position + offset; } }

    private void Update()
    {
        transform.position = targetPosition;
    }
}
