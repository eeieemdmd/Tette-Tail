using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public List<GameObject> Bullet;
    private Animator anima;
    public AudioSource audio;
    void Start()
    {
       // audio.GetComponent<AudioSource>();
        Bullet = new List<GameObject>();
        for(int i=0; i < transform.childCount; i++)
        {
            Bullet.Add(transform.GetChild(i).gameObject);
            transform.GetChild(i).gameObject.SetActive(false);
        }
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShooterCharge()
    {
        try
        {
            anima.SetTrigger("Shot");
        }
        catch
        {
            Debug.LogError("에러 발생");
            gameObject.SetActive(false);
        }
    }
    public void ShotTheBullet()
    {
        audio.Play();
        foreach (GameObject gm in Bullet)
        {
            if(gm.activeSelf == false)
            {
                gm.SetActive(true);
                break;
            }
        }
    }
}
