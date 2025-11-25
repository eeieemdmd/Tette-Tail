using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern3 : MonoBehaviour
{
    public Animator anima;
    public GameObject disObject;
    public List<GameObject> Bullets;
    public AudioSource audio;
    [Header("공격 오브젝트")]
    public GameObject bullet_L;
    public GameObject bullet_O;
    public GameObject bullet_T;
    public Transform shotPosition;

    [Header("속성")]
    public float CoolTime = 2f;
    private int AttackBulletNum= 5; // 한번에 공격할 개수
    public int AttackCount = 8;

    [Header("공격 사용")]
    public bool isattack = false; // 아직까진 수동임

    private float currentTime = 0;
    private int currentAttackCount = 0;

    private void Start()
    {
        anima = GetComponent<Animator>();
        Bullets = new List<GameObject>();
        GameObject obj;
        for(int i=1; i<=30; i++)
        {
            int num = Random.Range(0, 3);
            if(num == 0)
            {
                obj = Instantiate(bullet_T);
            }
            else if(num == 1)
            {
                obj = Instantiate(bullet_L);
            }
            else
            {
                obj = Instantiate(bullet_O);
            }
            obj.transform.SetParent(shotPosition);
            Bullets.Add(obj);
            obj.SetActive(false);

        }
        currentTime = CoolTime;
    }
    private void Update()
    {
        if (!isattack) return;
        currentTime += Time.deltaTime;
        if(currentTime >= CoolTime && currentAttackCount < AttackCount)
        {
            Shots();
            currentAttackCount++;
            currentTime = 0;
        }
        else if (currentAttackCount >= AttackCount)
        {
            Debug.LogWarning("공격이 끝남");
            isattack = false;
            currentAttackCount = 0;
            currentTime = 0;
            StartCoroutine(wait());
        }

    }
    public void AudioOn()
    {
        audio.Play();
    }
    public void Shots()
    {
        int count = 0;
        int[] rotates1 = { 0, 20, -20, 40, -40 };
        int[] rotates2 = { 0, 10, -10, 30, -30 };
        int[] rotates3 = { 0, 35, -35, 45, -45 };
        foreach (GameObject obj in Bullets)
        {
            if(count < AttackBulletNum && obj.activeSelf == false)
            {
                obj.SetActive(true);
                obj.transform.position = shotPosition.position;
                int af = Random.Range(0, 3);
                if (af== 0)
                {
                    obj.transform.rotation = Quaternion.Euler(0f, 0f, rotates1[count]);
                }
                else if(af == 1)
                {
                    obj.transform.rotation = Quaternion.Euler(0f, 0f, rotates2[count]);
                }
                else
                {
                    obj.transform.rotation = Quaternion.Euler(0f, 0f, rotates3[count]);
                }
                count++;
            }
           
        }
    }

    IEnumerator wait()
    {
        anima.SetBool("Boss3", false);
        yield return new WaitForSeconds(2f);
        disObject.SetActive(false);
    }
}
