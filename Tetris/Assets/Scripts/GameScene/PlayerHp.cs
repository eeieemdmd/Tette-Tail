using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{

    [Header("플레이어 체력")]
    public AudioSource audio;
    public int Hp = 10;
    public Sprite[] PlayerState;
    private SpriteRenderer renderer;
    public BoxCollider2D box;
    private Animator PlayerHit;
    public int MaxHp;
    void Start()
    {
    
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = PlayerState[0];
        box = GetComponent<BoxCollider2D>();
        PlayerHit = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        box.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        float Hps = (float)Hp / MaxHp;
        if (Hps <= 0.75 && Hps > 0.5)
        {
            renderer.sprite = PlayerState[1];
        }
        else if (Hps <= 0.5 && Hps > 0.25)
        {
            renderer.sprite = PlayerState[2];
        }
        else if (Hps <= 0.25 && Hps > 0)
        {
            renderer.sprite = PlayerState[3];
        }
        else if(Hps <= 0)
        {
            renderer.sprite = PlayerState[4];
            Debug.Log("Player죽음!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public void PlayerBoxOn()
    {
        box.enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("HitPlayer"))
        {
            Hp -= 1;
            box.enabled = false;
            PlayerHit.SetTrigger("PlayerHit");
            audio.Play();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("HitPlayer2"))
        {
            Hp -= 2;
            box.enabled = false;
            PlayerHit.SetTrigger("PlayerHit");
            audio.Play();
        }
    }
}
