using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCheck : MonoBehaviour
{
    public int PieceDownCount;
    public int TetrominoCount = 20;
    public List<GameObject> PieceObject;

    public List<Sprite> PieceSprites;
    private void Start()
    {
        for(int i=0; i<PieceObject.Count; i++)
        {
            SpriteRenderer red = PieceObject[i].GetComponent<SpriteRenderer>();
            red.sprite = PieceSprites[Random.RandomRange(0, PieceSprites.Count)];
        }
    }
    private void OnEnable()
    {
        foreach (GameObject block in PieceObject)
        {
            block.SetActive(true);
        }
        }
    public void SetThePiece()
    {
        foreach(GameObject block in PieceObject)
        {
            if(block.activeSelf == true)
            {
                block.SetActive(false);
                break;
            }
        }
    }
}
