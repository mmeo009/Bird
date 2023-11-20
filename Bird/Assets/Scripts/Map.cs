using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Creater creater;
    void Update()
    {
        if (creater == null)
        {
            creater = FindAnyObjectByType<Creater>();
        }
        transform.Translate(Vector3.left * creater.speed);
        if (this.transform.position.x <= -20)
        {
            creater.MapGen(this.transform.position.x + 60);
            Destroy(this.gameObject);
        }
    }
}
