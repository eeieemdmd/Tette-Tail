using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager instance;
    public List<GameObject> EnergyBall;

    // 에너지볼 발사
    public bool isAttack = false;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<EnergyBall>() != null) {
                EnergyBall.Add(transform.GetChild(i).gameObject);
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void TurnOnEnergyBall()
    {
        foreach(GameObject energy in EnergyBall)
        {
            if(energy.activeSelf == false)
            {
                energy.SetActive(true);
                break;
            }
        }
    }



}
