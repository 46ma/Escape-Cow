using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Player setting
    [Header("Movement Setting")]
    private Rigidbody2D matPlayerRigid;
    private Animator matPlayerAnim;
    [SerializeField] private float speed = 5; //Speed in axis X
    [SerializeField] private float gravity = 5; //speed in axis y

    [Header("Ground Check Setting")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    //Condition check
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isSign;

    private PlayerHealth health;

    //Audio
    public AudioSource jumpSound; //ใช้เก็บเสียงกระตอนผู้เล่นกระโดด

    private void Awake()
    {
        matPlayerRigid = GetComponent<Rigidbody2D>();
        matPlayerAnim = GetComponent<Animator>();
        health = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        //If player is dead or player hit sign then player can't move
        if (!health.IsDead() && !isSign)
        {
            matPlayerRigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, matPlayerRigid.velocity.y);

            //Walking animation
            matPlayerAnim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        //Face right when walk right
        if ((Input.GetAxis("Horizontal") > 0.01f) && !health.IsDead())
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        //Face left when walk left
        if ((Input.GetAxis("Horizontal") < -0.01f) && !health.IsDead())
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }

        //Check if player on ground then player can jump
        if (Input.GetKey(KeyCode.Space) && isGrounded == true && !health.IsDead())
        {
            jumpSound.Play();
            matPlayerRigid.velocity = new Vector2 (matPlayerRigid.velocity.x, gravity); // Use garvity to jump

            //Jump animation
            matPlayerAnim.SetTrigger("jump");
        }
    }

    // Speed Boost
    public void BoostSpeed(float speedAmount, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(speedAmount, duration));
    }

    private IEnumerator SpeedBoostRoutine(float speedAmount, float time)
    {
        speed += speedAmount;
        matPlayerAnim.SetTrigger("dash");
        yield return new WaitForSeconds(time);
        speed -= speedAmount;
    }

    // Stun Player
    public void StunPlayer(float duration)
    {
        StartCoroutine(ResetSign(duration));
    }

    IEnumerator ResetSign(float duration)
    {
        isSign = true;
        matPlayerAnim.SetTrigger("spin");
        yield return new WaitForSeconds(duration);
        isSign = false;
    }
}
