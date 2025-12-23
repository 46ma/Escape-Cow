using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMoving : MonoBehaviour
{
    public Transform posA, posB; //A position and B position for make Cow route
    public float cowSpeed = 5f; //Speed
    Vector2 targetPos;

    //effect
    public GameObject cowSpecialEffect;

    //sound
    [SerializeField] AudioSource cowSound;

    void Start()
    {
        targetPos = posA.position;

    }

    void Update()
    {
        //Move to A and B position
        if (Vector2.Distance(transform.position,posA.position)<.1f)targetPos = posB.position;
        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, cowSpeed * Time.deltaTime);

        //Face right if walk to right side
        if (Vector2.Distance(transform.position, posA.position) < .1f)
        {
            transform.localScale = new Vector3(-0.7f, 0.7f, 1f);
        }

        //Face left if walk to left side
        if (Vector2.Distance(transform.position, posB.position) < .1f)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if hit player
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(cowSpecialEffect,transform.position,Quaternion.identity);
            cowSound.Play();
        }
    }
   
}
