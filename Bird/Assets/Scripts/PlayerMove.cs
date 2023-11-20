#pragma warning disable IDE0051
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject[] text;
    public bool amISaying = false;
    public int sorry = 0;
    Creater creater;
    public AudioClip[] clip;
    public AudioSource audio;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        creater = FindAnyObjectByType<Creater>();
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(transform.position.y <= -6 || transform.position.y >= 6)
        {
            creater.isGameOver = true;
            rb.gravityScale = 0;
        }
    }
    void OnJump(InputValue value)
    {
        if(creater.isGameOver == false)
        {
            rb.velocity = Vector2.up * 3;
            if (amISaying == false)
            {
                int num;
                if (sorry == 0)
                {
                    num = Random.Range(0, text.Length - 3);
                    if (num == 25)
                    {
                        sorry = 1;
                    }
                }
                else if (sorry == 1)
                {
                    num = 26;
                    sorry++;
                }
                else if (sorry == 2)
                {
                    num = 42;
                    sorry++;
                }
                else if(sorry == 3)
                {
                    num = 43;
                    sorry = 0;
                }
                else
                {
                    num = Random.Range(0, text.Length - 3);
                }
                text[num].SetActive(true);
                amISaying = true;
                audio.clip = clip[Random.Range(0, clip.Length)];
                audio.Play();
                Invoke("RemoveText", 0.2f);
            }
        }
    }
    void RemoveText()
    {
        for(int i = 0; i < text.Length; i++)
        text[i].SetActive(false);
        amISaying = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            creater.isGameOver = true;
            rb.gravityScale = 0;
        }
    }
}
