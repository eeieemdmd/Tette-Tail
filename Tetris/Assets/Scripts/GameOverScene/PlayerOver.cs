using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOver : MonoBehaviour
{
    public float Power = 300;
    public List<Rigidbody2D> pieces;
    public GameObject Texts;
    public AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        foreach (Rigidbody2D rd in pieces)
        {
            rd.gravityScale = 0;
            StartCoroutine(EndStart());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EndStart()
    {
        yield return new WaitForSeconds(1.5f);
      
        OnPop();
        audio.Play();
        yield return new WaitForSeconds(1f);
        Texts.SetActive(true);
    }
   
    public void OnPop()
    {
        foreach(Rigidbody2D rd in pieces)
        {
            rd.gravityScale = 1;
            rd.AddForce(Random.insideUnitCircle.normalized * Power, ForceMode2D.Impulse);
            rd.AddTorque(Power*5);
        }

    }
}
