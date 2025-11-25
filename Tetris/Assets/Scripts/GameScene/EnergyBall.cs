using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBall : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    public AudioSource audio;
    private Vector3 startPoint;
    public List<Transform> endPointObject;
    private Vector3 endPoint;
    public float Speed = 2f;
    public float CheckDestance = 2f;
    public float WaitTime = 2f;
    public int AttackDamageMin = 5;
    public int AttackDamageMax = 10;
    [SerializeField]
    private BoseHp bosshp;
    public Sprite Origin;
    AttackManager isMoving;
    Animator anima;
    private bool DameageOn = true;
    bool endstart = false;

    private float currentTime = 0;
    private void Start()
    {
        //audio.GetComponentInParent<AudioSource>();
        damageText.gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().sprite = Origin;
        anima = GetComponent<Animator>();
        startPoint = transform.position;
        endPoint = endPointObject[Random.Range(0, endPointObject.Count-1)].position;
        anima.enabled = false;
        endstart = false;
    }

    void Update()
    {
        if (GameManager.instance.whoturn == GameManager.WhoTurn.tetris) return;

        if (!endstart) { StartCoroutine(DieStart());  endstart = true; }
        currentTime += Time.deltaTime;
        if (currentTime <= WaitTime) return;
        
            



            // 종료 조건
            if (Vector3.Distance(transform.position, endPoint) < CheckDestance&& DameageOn)
            {
                anima.enabled = true;
            StopCoroutine(DieStart());
            audio.Play();
            damageText.gameObject.SetActive(true);
            bosshp.bossHpBar.gameObject.SetActive(true);
            DameageOn = false;
            int Damage = Random.Range(AttackDamageMin, AttackDamageMax);
            if (Damage > 0)
            {
                damageText.text = "-" + Damage;
            }
            else
            {
                damageText.text = "MISS";
            }
            bosshp.Hp -= Damage;
            damageText.transform.position = transform.position;
            StartCoroutine(End());
            }
            else if(DameageOn)
            {

            Vector3 dir = endPoint - startPoint;
            transform.position += Speed * dir.normalized * Time.deltaTime;
             }
            
        
    }


    IEnumerator DieStart()
    {
        yield return new WaitForSeconds(5f);
        currentTime = 0;
        anima.enabled = false;
        DameageOn = true;
        transform.position = startPoint;
        gameObject.GetComponent<SpriteRenderer>().sprite = Origin;
        endPoint = endPointObject[Random.Range(0, endPointObject.Count - 1)].position;
        endstart = false;
        damageText.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
        IEnumerator End()
    {
        yield return new WaitForSeconds(1f);
        currentTime = 0;
        anima.enabled = false;
        DameageOn = true;
        transform.position = startPoint;
        gameObject.GetComponent<SpriteRenderer>().sprite = Origin;
        endPoint = endPointObject[Random.Range(0, endPointObject.Count - 1)].position;
        endstart = false;
        damageText.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }



}
