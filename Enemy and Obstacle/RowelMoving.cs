using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rowelMoving : MonoBehaviour
{
    public Transform posA, posB;
    public float rowelSpeed = 7f; //Rowel speed
    Vector2 targetPos;

    //effect
    public GameObject rowelEffect;

    //sound
    [SerializeField] AudioSource rowelSound; 

    void Start()
    {
        targetPos = posA.position; //กำหนดตำแหน่งเป้าหมายคือตำแหน่ง A

    }

    void Update()
    {
        //Make rowel move to A position and B position
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;
        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, rowelSpeed * Time.deltaTime); ;

        /*
        if (Vector2.Distance(transform.position, posA.position) < .1f)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
        }
        if (Vector2.Distance(transform.position, posB.position) < .1f)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        }
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if rowel hit player
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(rowelEffect, transform.position, Quaternion.identity);
            rowelSound.Play();
        }
    }
}
