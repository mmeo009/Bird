using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Creater : MonoBehaviour
{
    public GameObject[] maps;
    public float speed;
    public int score;
    public TMP_Text text;
    public bool isGameOver = false;
    public GameObject go;
    private void Update()
    {
        if(isGameOver == false)
        {
            speed += 0.001f * Time.deltaTime;
            score += (int)(Time.time);
        }
        else
        {
            speed = 0;
            go.SetActive(true);
        }
        text.text = $"SCORE : {score}";
    }

    public void MapGen(float amount)
    {
        GameObject map = (GameObject)Instantiate(maps[Random.Range(0, maps.Length)]);
        map.transform.position = new Vector2(amount, 0);
    }
}