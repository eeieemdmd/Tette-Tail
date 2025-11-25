using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{

    public float showSecond = 2;
    public float LatherHpBarSpeed;
    public Slider ThisHpBar;
    public Slider LateHpBar;
    public GameObject bose;
    // Start is called before the first frame update
    void Start()
    {
        //bose = GameObject.FindObjectOfType<Boss>().gameObject;
        transform.position = bose.transform.position;
        ThisHpBar = GetComponent<Slider>();
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StopCoroutine(ActiveOff());
        StartCoroutine(ActiveOff());   
    }
    // Update is called once per frame
    void Update()
    {
        LateHpBar.value = Mathf.Lerp(LateHpBar.value, ThisHpBar.value, LatherHpBarSpeed*Time.deltaTime);
    }
    IEnumerator ActiveOff()
    {
        yield return new WaitForSeconds(showSecond);
        gameObject.SetActive(false);
    }
}
