using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Use UI
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class playerMovement : MonoBehaviour
{
    //Player setting
    private Rigidbody2D matPlayerRigid;
    private Collider2D matPlayerColli;
    private Animator matPlayerAnim;
    [SerializeField] private float speed; //Speed in axis X
    [SerializeField] private float gravity; //speed in axis y

    //Condition check
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isSign;

    //UI
    [SerializeField] intSo ScoreSO; //Collect score in Scripttable Object
    [SerializeField] TextMeshProUGUI scoreText; 
    [SerializeField] private int totalHeart;
    [SerializeField] private int totalCard;//เก็บบัตรนักศึกาาทั้งหมด
    public studentCard studentCardCounter; //ตัวนับจำนวนบัตรนักศึกษา
    public Image[] hearts; //ตัวเก็บภาหัวใจในตัวผู้เล่น

    //Audio
    public AudioSource jumpSound; //ใช้เก็บเสียงกระตอนผู้เล่นกระโดด

    private void Awake()
    {
        totalHeart = 3; //กำหนดค่าเลือด
        speed = 5; //กำหนดค่าความเร็วสำหรับการเคลื่อนที่ในแกน X
        gravity = 5; //กำหนดค่าความเร็วเคลื่อนที่ในแกน Y
        matPlayerRigid = GetComponent<Rigidbody2D>();
        matPlayerColli = GetComponent<Collider2D>();
        matPlayerAnim = GetComponent<Animator>();
        scoreText.text = "Score: " + ScoreSO.Value.ToString(); //บอกให้แสดง UI ที่ใช้ scoreTxet แสดง "Score" + คะแนนที่เก็บไว้ใน scoreSO
    }

    void Update()
    {
        //If player is dead or player hit sign then player can't move
        if(isDead == false && isSign == false)
        {
            matPlayerRigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, matPlayerRigid.velocity.y);

            //Walling animation
            matPlayerAnim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        //Face right when walk right
        if ((Input.GetAxis("Horizontal") > 0.01f) && isDead == false)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        //Face left when walk left
        if ((Input.GetAxis("Horizontal") < -0.01f) && isDead == false)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }

        //Check if player on ground then player can jump
        if (Input.GetKey(KeyCode.Space) && isGrounded == true && isDead == false)
        {
            jumpSound.Play(); //เล่นเสียงที่กำหนดตอนผู้เล่นกดกระโดด
            matPlayerRigid.velocity = new Vector2 (matPlayerRigid.velocity.x, gravity); //กระโดดโดยใช้ค่า garvity

            //Jump animation
            matPlayerAnim.SetTrigger("jump");
        }

        //If player heart less then 0 then play player dead animation
        if (totalHeart <= 0 && isDead != true)
        {
            matPlayerAnim.SetTrigger("dead");
            isDead = true;
            SceneManager.LoadScene("gameover"); //Load game over scene
        }

        //Animation test
        /*
        if (Input.GetKey(KeyCode.H))
        {
            matPlayerAnim.SetTrigger("hurt");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
           matPlayerAnim.SetTrigger("dash");
        }
        if (Input.GetKey(KeyCode.T))
        {
            matPlayerAnim.SetTrigger("spin");
        }
        */

    }

    //Update player heart
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i<totalHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    //Check for collisions
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if player on ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        //Check if player hit thorn
        if (collision.gameObject.CompareTag("thorn"))
        {
            totalHeart -= 1;
            UpdateHearts();
            Destroy(collision.gameObject);
            matPlayerAnim.SetTrigger("hurt");
        }    

        //Check if player hit syringe
        if (collision.gameObject.CompareTag("syringe"))
        {
            if (totalHeart >= 3) //If player have totalHeart more than 3 then totalHeart + 0
            {
                totalHeart += 0;
                UpdateHearts();
                Destroy(collision.gameObject);
            }
            else //If player have less than 3 heart then totalHeart + 1
            {
                totalHeart += 1;
                UpdateHearts();
                Destroy(collision.gameObject);
            }
        }

        //firtAidCheck
        if (collision.gameObject.CompareTag("firstAidKit"))
        {
            totalHeart -= totalHeart;
            totalHeart += 3;
            UpdateHearts();
            Destroy(collision.gameObject);
        }

        //Coin check
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin Score");
            ScoreSO.Value += 100;
            scoreText.text = "Score: " + ScoreSO.Value.ToString(); //บอกให้แสดง UI ที่ใช้ scoreTxet แสดง "Score" + คะแนนที่เก็บไว้ใน scoreSO
            Destroy(collision.gameObject);
        }

        //Speed boost
        if (collision.gameObject.CompareTag("speedBoost"))
        {
            speed += 10;
            Destroy(collision.gameObject);
            matPlayerAnim.SetTrigger("dash");
            StartCoroutine(resetSpeedBoost());
        }
        IEnumerator resetSpeedBoost()
        {
            yield return new WaitForSeconds(3f);
            speed -= 10;
        }

        //Check if player hit cow
        if (collision.gameObject.CompareTag("cow"))
        {
            totalHeart -= 1;
            matPlayerAnim.SetTrigger("hurt");
            UpdateHearts();
        }

        //Check if player hit cow in car
        if (collision.gameObject.CompareTag("cowInCar"))
        {
            totalHeart -= 3;
            matPlayerAnim.SetTrigger("hurt");
            UpdateHearts();
        }

        //Check if player hit student card
        if (collision.gameObject.CompareTag("studentCard"))
        {
            ScoreSO.Value += 500;
            totalCard += 1;
            scoreText.text = "Score: " + ScoreSO.Value.ToString(); //บอกให้แสดง UI ที่ใช้ scoreTxet แสดง "Score" + คะแนนที่เก็บไว้ใน scoreSO
            studentCardCounter.showStudentCard(totalCard); //ให้แสดง UI studentCardCounter เพิ่มจำนวนตาม totalCard 
            Destroy(collision.gameObject);
        }

        //Check if player hit ST
        if (collision.gameObject.CompareTag("ST"))
        {
            ScoreSO.Value += 1000;
            scoreText.text = "Score: " + ScoreSO.Value.ToString(); //บอกให้แสดง UI ที่ใช้ scoreTxet แสดง "Score" + คะแนนที่เก็บไว้ใน scoreSO
            //UpdateScoreText();
            //coinCounter.showCoin(totalCoin);
            Destroy(collision.gameObject);
        }

        //Check if player hit sign
        if (collision.gameObject.CompareTag("Sign"))
        {
            Destroy(collision.gameObject);
            isSign = true; //ทำให้ isSign เป็นจริงเพื่อให้ผู้เล่นขยับไม่ได้ ตามเงื่อนไขที่เขียนไว้ตรงตรวจสอบการเดิน
            StartCoroutine(ResetSign());
            matPlayerAnim.SetTrigger("spin");
        }
        IEnumerator ResetSign()
        {
            yield return new WaitForSeconds(2f);
            isSign = false;
        }

    }

    //Check if not on ground
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
       
    }
}
