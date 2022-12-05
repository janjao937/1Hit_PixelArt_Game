using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField]private Transform player;
    [Range(0.01f,1)]
    [SerializeField]private float SmoothValue = 0.5f;

    private Vector3 camOffset;

    private void Start() 
    {
        camOffset = transform.position-player.transform.position;
    }

    private void LateUpdate() 
    {
        Vector3 newPos = player.transform.position+camOffset;
        transform.position = Vector3.Slerp(transform.position,newPos,SmoothValue);
    }



}
