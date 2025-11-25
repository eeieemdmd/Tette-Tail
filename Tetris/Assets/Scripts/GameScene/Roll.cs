using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Vector3 dir = new Vector3(0, 0, 1);
        transform.Rotate(dir * speed * Time.deltaTime);
    }
}
