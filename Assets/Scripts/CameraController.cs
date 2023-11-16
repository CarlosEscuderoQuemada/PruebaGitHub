using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    private void LateUpdate()//Se le llama una vez despues de los frames y de quese hayan completado
    {
        transform.position = player.transform.position + offset;
    }
}
