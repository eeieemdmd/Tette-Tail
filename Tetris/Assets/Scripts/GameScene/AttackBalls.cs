using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBalls : MonoBehaviour
{
    public BoxCollider2D box;

    private void Start()
    {
      
        box = GetComponentInParent<BoxCollider2D>();
        box.enabled = false;
        gameObject.SetActive(false);
    }

    public void LaserOn()
    {
        box.enabled = true;
 
    }
    public void LaserOff()
    {
        box.enabled = false;
        gameObject.SetActive(false);
    }
}
