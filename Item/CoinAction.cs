using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAction : MonoBehaviour
{
    //Effect
    public GameObject specialEffect;
    public GameObject textEffect;

    //Sound
    [SerializeField] AudioSource colletCoinSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ถ้าผู้เล่นเดินชนเหรียญจะแสดงเอฟเฟคและเล่นเสียง
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(specialEffect, transform.position, Quaternion.identity);
            Instantiate(textEffect, transform.position, Quaternion.identity);
            colletCoinSound.Play();
        }
    }
   
}
