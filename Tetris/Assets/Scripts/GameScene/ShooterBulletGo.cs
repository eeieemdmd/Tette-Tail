using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBulletGo : MonoBehaviour
{

    public bool leftBullet;
    public float speed = 10;
    private Animator anima;
    private bool move = true;
    public Sprite Originar;
    private Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        Pos = transform.position;
        anima = GetComponent<Animator>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Originar;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move) return;
        transform.position += transform.right * speed * Time.deltaTime;
    }
   
    public void Off()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Originar;
        transform.position = Pos;
        move = true;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (leftBullet)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("OffLeftBullet"))
            {
                anima.SetTrigger("Pop");
                move = false;
            }
        }
        else
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("OffRightBullet"))
            {
                anima.SetTrigger("Pop");
                move = false;
            }
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anima.SetTrigger("Pop");
            move = false;
        }
    }
}
