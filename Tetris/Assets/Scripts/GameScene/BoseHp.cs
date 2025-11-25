using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BoseHp : MonoBehaviour
{
    private Boss bossAttackSystem;
    public Slider bossHpBar;
    public int Hp;
    private bool boseSuviver;
    public GameObject[] BoseDie;
    public GameObject[] bossAttackObject;

    private Animator anima;
    private void Start()
    {
        boseSuviver = true;
        Hp = 100;
        bossAttackSystem = GetComponent<Boss>();
        anima = GetComponent<Animator>();
   
    }
    private void Update()
    {
        bossHpBar.value = Hp;
        if (Hp > 0) return;
        if (boseSuviver)
        {
            bossAttackSystem.GameObjectsOff();
            bossAttackSystem.enabled = false;
            bossAttackObject[0].SetActive(false);
            bossAttackObject[1].SetActive(true);
            
            Debug.Log("º¸½º »ç¸Á!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            anima.SetTrigger("BossDie");
            StartCoroutine(BossDie());
            boseSuviver = false;
        }
        
    }

    IEnumerator BossDie()
    {
        BoseDie[0].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        BoseDie[1].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        BoseDie[2].SetActive(true);
        
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("GameWin");
    }
}
