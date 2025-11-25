using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{

    public float speed = 5;
    public float SurviveTime = 5;
    public GameObject Pop;
   private Animator renderer;
    public Sprite Originar;
    public bool move = true;
    SpriteRenderer sp;

    private float currentTime;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = Originar;
        Pop = transform.GetChild(0).gameObject;
        Pop.SetActive(false);
        renderer = GetComponent<Animator>();
        renderer.enabled = false;
        move = true;
       
    }


    void Update()
    {
        if (!move) return;
        currentTime += Time.deltaTime;
        transform.position += -transform.up * speed * Time.deltaTime;
        if(currentTime > SurviveTime)
        {

            renderer.enabled = false;
            Pop.SetActive(false);
            gameObject.SetActive(false);
            currentTime = 0;
        }
    }
    IEnumerator QutTime()
    {
        currentTime = 0;
        Pop.SetActive(true);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.6f);
        move = true;
        sp.sprite = Originar;
        renderer.enabled = false;
        Pop.SetActive(false);
        gameObject.SetActive(false);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 타격");
            move = false;
            StartCoroutine(QutTime());
        }
    }

  
}
