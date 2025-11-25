using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;


public class AttackPettern1 : MonoBehaviour
{
    public GameObject disObject;

    public List<GameObject> attackPattern;

    [Header("공격 오브젝트")]
    public GameObject objects;

    [Header("속성")]
    public float CoolTime = 2f;
    public int AttackBlock = 3;
    public int AttackCount = 8;

    [Header("공격 사용")]
    public bool isattack = false; // 아직까진 수동임

    private float currentTime = 0;
    private int currentAttackCount = 0;

 
    private void Start()
    {
        
     
        attackPattern= new List<GameObject>();

        GameObject obj;
        for (int i = 0; i < objects.transform.childCount; i++)
        {
            obj = objects.transform.GetChild(i).gameObject;
            attackPattern.Add(obj);
            obj.GetComponent<BoxCollider2D>().enabled = false;
            obj.GetComponent<Animator>().enabled = false;
        }
        currentTime = CoolTime;
    }
 
    private void Update()
    {
        if (!isattack) return;
        currentTime += Time.deltaTime;
        if(currentTime >= CoolTime && currentAttackCount<AttackCount)
        {
            Debug.Log("소한");
            AttackOn();
            currentAttackCount++;
            currentTime = 0;
        }
        else if(currentAttackCount >= AttackCount)
        {
            Debug.LogWarning("공격이 끝남");
            isattack = false;
            currentAttackCount = 0;
            currentTime = 0;
            StartCoroutine(wait());
        }
       
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        disObject.SetActive(false);
    }
    public void AttackOn()
    {
        //Animator anima;

        for (int i=0; i <AttackBlock; i++)
        {
            

            if(Random.Range(0, 3) == 0)
            {
                BlocksSet_O(Random.Range(0, attackPattern.Count));
            }
            else if (Random.Range(0, 3) == 1)
            {
                BlocksSet_Z(Random.Range(0, attackPattern.Count));
            }
            else
            {
                BlocksSet_T(Random.Range(0, attackPattern.Count));
            }
            //anima = attackPattern[Random.Range(0, attackPattern.Count)].GetComponent<Animator>();
            //anima.enabled = true;

        }
    }

    // T자모양 패턴
    public void BlocksSet_T(int num)
    {
        Animator anima;
        int down= num, left= num, right = num;
       

        if (num + 1 < 44)
            right +=1;
        if (num - 11 > -1)
            down -= 11;
        if (num - 1 > -1)
            left -= 1;

        int[] group = { down, left, right, num };
        for (int i = 0; i < group.Length; i++)
        {
            anima = attackPattern[group[i]].GetComponent<Animator>();
            anima.enabled = true;
        }
    }
    // Z자 모양 패턴
    public void BlocksSet_Z(int num)
    {
        Animator anima;
        int up = num, upleft = num, right = num;


        if (num + 1 < 44)
            right += 1;
        if (num + 11 < 44)
            up += 11;
        if (num + 10 < 44)
            upleft += 10;

        int[] group = { up, upleft, right, num };
        for (int i = 0; i < group.Length; i++)
        {
            anima = attackPattern[group[i]].GetComponent<Animator>();
            anima.enabled = true;
        }
    }

    // O자 모형 패턴
    public void BlocksSet_O(int num)
    {
        Animator anima;
        int up = num, upright = num, right = num;


        if (num + 1 < 44)
            right += 1;
        if (num + 11 < 44)
            up += 11;
        if (num + 12 < 44)
            upright += 12;

        int[] group = { up, upright, right, num };
        for (int i = 0; i < group.Length; i++)
        {
            anima = attackPattern[group[i]].GetComponent<Animator>();
            anima.enabled = true;
        }
    }
}
