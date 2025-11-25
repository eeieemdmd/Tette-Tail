using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CinemachineVirtualCameraBase cam;

    public enum WhoTurn
    {
        tetris,
        boss,
        gameWin
    }
    [Header("현재 턴")]
    public WhoTurn whoturn;
    [Header("테트리스 오브젝트")]
    public GameObject tetrisObject;
    public GameObject tetrisZoom;
    [Header("보스 오브젝트")]
    public GameObject bossObject;

    private AttackManager attackmanager;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        TetrisTurn();
        attackmanager = AttackManager.instance;
        TrunChange();
    }

    public void TetrisTurn()
    {
        whoturn = WhoTurn.tetris;
    }
    public void BossTurn()
    {
        whoturn = WhoTurn.boss;
    }
    public void TrunChange()
    {
        switch (whoturn) {
            case WhoTurn.tetris:
                attackmanager.isAttack = false;

                cam.Follow = tetrisZoom.transform;

                tetrisObject.SetActive(true);
                bossObject.SetActive(false);
                break;
            case WhoTurn.boss:
                attackmanager.isAttack = true;

                cam.Follow = bossObject.transform;

                tetrisObject.SetActive(false);
                bossObject.SetActive(true);
                break;
        }
    }
  
}
