using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RE : MonoBehaviour
{
    public Image im;
    Creater creater;
    private void Update()
    {
        if(creater == null)
        {
            creater = FindAnyObjectByType<Creater>();
        }
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);
        im.color = randomColor;
    }
    public void ReStart()
    {
        SceneManager.LoadScene("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
