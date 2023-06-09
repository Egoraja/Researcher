using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform rogue;
    

    private void Start()
    {
        offset = transform.position - rogue.position;
        
    }

    
    private void Update()
    {
        transform.position = rogue.position + offset;
    }
}
