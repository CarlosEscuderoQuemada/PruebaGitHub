using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotadorDeCubo : MonoBehaviour
{
    public float RotationSpeed;

    void FixedUpdate()
    {
        transform.Rotate(1 * RotationSpeed, 1 * RotationSpeed, 1 * RotationSpeed);
    }
}
