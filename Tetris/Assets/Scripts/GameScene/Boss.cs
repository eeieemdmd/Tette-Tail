using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private AttackPettern1 attack1;
    private AttackPettarn2 attack2;
    private AttackPattern3 attack3;
    private AttackPettern4 attack4;

    public GameObject[] attackObject;
    public Animator anima;

    private bool waittrue = true;
   // public bool AttackStart = false;
    private void Start()
    {
        anima = GetComponent<Animator>();
        attack1 = GetComponent<AttackPettern1>();
        attack2 = GetComponent<AttackPettarn2>();
        attack3 = GetComponent<AttackPattern3>();
        attack4 = GetComponent<AttackPettern4>();

        for(int i=0; i<attackObject.Length; i++)
        {
            attackObject[i].SetActive(false);
        }
    }
    private void OnEnable()
    {
        // AttackStart = true;
        waittrue = true;
        StartCoroutine(StartWait());
    }
    private void Update()
    {
        if (attack1.isattack == true|| attack2.isattack == true|| attack3.isattack == true|| attack4.isattack == true ||waittrue) return;
        StartCoroutine(EndWait());
    }

    public void ChangeTurns()
    {
        GameManager.instance.TetrisTurn();
        GameManager.instance.TrunChange();
    }
    IEnumerator StartWait()
    {
        int num = Random.Range(1, 5);
        yield return new WaitForSeconds(3f);
        switch (num)
        {
            case 1:
                anima.SetTrigger("Boss1");
                attackObject[0].SetActive(true);
                break;
            case 2:
                anima.SetBool("Boss2", true);
                attackObject[1].SetActive(true);
                break;
            case 3:
                anima.SetBool("Boss3", true);
                attackObject[2].SetActive(true);
                break;
            case 4:
                anima.SetTrigger("Boss4");
                attackObject[3].SetActive(true);
                break;
        }
        yield return new WaitForSeconds(1.5f);
        switch (num)
        {
            case 1:
                attack1.isattack = true;

                break;
            case 2:
                attack2.isattack = true;

                break;
            case 3:
                attack3.isattack = true;

                break;
            case 4:
                attack4.isattack = true;
     
                break;
        }
        waittrue = false;
    }
    public void GameObjectsOff()
    {
        attack1.enabled = false;
        attack2.enabled = false;
        attack3.enabled = false;
        attack4.enabled = false;
    }
    IEnumerator EndWait()
    {
        yield return new WaitForSeconds(2f);
        ChangeTurns();
    }
    }
