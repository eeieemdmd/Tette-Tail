using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPettern4 : MonoBehaviour
{

    public GameObject disObject;

    [Header("공격 오브젝트")]
    public List<GameObject> shooters;

    [Header("속성")]
    public float CoolTime = 2f;
    public int AttackCount = 8;

    [Header("공격 사용")]
    public bool isattack = false; // 아직까진 수동임

    private float currentTime = 0;
    private int currentCount = 0;

    private void Start()
    {
        currentTime = CoolTime;
    }
    private void Update()
    {
        if (!isattack) return;
        currentTime += Time.deltaTime;
        if (currentTime >= CoolTime && currentCount < AttackCount)
        {
            int num = Random.Range(0, 4);
            shooters[num].GetComponent<Shooter>().ShooterCharge();

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
        yield return new WaitForSeconds(2f);
        disObject.SetActive(false);
    }
}
