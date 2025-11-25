using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Pattern1HitPlayer : MonoBehaviour
{
    BoxCollider2D box;
    Animator anima;
    public AudioSource audio;
    public RuntimeAnimatorController nextAnimator;
    public RuntimeAnimatorController beforeAnimator;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColliderOn()
    {
        anima.runtimeAnimatorController = nextAnimator;
        audio.Play();
        box.enabled = true;
    }
    public void ColliderOff()
    {
        anima.runtimeAnimatorController = beforeAnimator;
        box.enabled = false;
        anima.enabled = false;
    }
}
