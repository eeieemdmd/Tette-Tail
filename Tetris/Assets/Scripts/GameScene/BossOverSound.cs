using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOverSound : MonoBehaviour
{

    public AudioSource audio;
    public AudioSource Otheraudio;
    // Start is called before the first frame update
    void Start()
    {
        audio =GetComponent<AudioSource>();
        Over();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Over()
    {
        audio.Play();
        Otheraudio.Stop();
    }
}
