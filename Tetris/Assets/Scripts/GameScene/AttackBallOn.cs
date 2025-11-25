using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBallOn : MonoBehaviour
{

    private GameObject gm;
    public AudioSource anima;
    private void Start()
    {
        gm = transform.GetChild(0).gameObject;
        //anima = GetComponent<AudioSource>();
    }
    public void LaserOn()
    {
        gm.SetActive(true);
        anima.Play();
    }
}
