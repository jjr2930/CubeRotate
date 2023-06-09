using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCube : MonoBehaviour
{
    public float speed = 120;
    public void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
