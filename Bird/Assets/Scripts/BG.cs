using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public SpriteRenderer sp;

    // Update is called once per frame
    void Update()
    {
            Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);
            sp.color = randomColor;
    }
}
