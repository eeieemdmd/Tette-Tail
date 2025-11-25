using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPettarn2 : MonoBehaviour
{

    public Animator anima;
    public GameObject disObject;
    [Header("공격 오브젝트")]
    public Animator left;
    public Animator midle;
    public Animator right;

    [Header("속성")]
    public float CoolTime = 3f;
    public int AttackCount = 8;

    [Header("공격 사용")]
    public bool isattack = false; // 아직까진 수동임
    private float currentTime = 0;
    private int currentCount = 0;
    void Start()
    {
        currentTime = CoolTime;
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isattack) return;
        currentTime += Time.deltaTime;
        if(currentTime >= CoolTime && currentCount < AttackCount)
        {
            int num = Random.Range(0, 3);
            if ( num == 0)
            {
                left.SetTrigger("LaserOn");
            }
            else if(num == 1)
            {
                right.SetTrigger("LaserOn");
            }
            else
            {
                midle.SetTrigger("LaserOn");
            }
            currentCount++;
            currentTime = 0;
        }
        else if (currentCount >= AttackCount)
        {
            Debug.LogWarning("공격이 끝남");
            isattack = false;
            currentCount = 0;
            currentTime = 0;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        anima.SetBool("Boss2", false);
        yield return new WaitForSeconds(2f);
        disObject.SetActive(false);
    }
}
