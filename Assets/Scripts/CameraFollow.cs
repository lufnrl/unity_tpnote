using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target; // L'objet à suivre
    [SerializeField] Vector3 offset; // Décalage entre la caméra et l'objet

    void Update()
    {
        transform.position = target.position + offset;   
    }
}