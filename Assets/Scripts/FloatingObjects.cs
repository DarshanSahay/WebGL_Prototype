using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjects : MonoBehaviour
{
    [SerializeField] private float yRotation;
    void Update()
    {
        transform.Rotate(0, yRotation, 0);
    }
}
