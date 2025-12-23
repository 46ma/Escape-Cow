using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornObstacle : MonoBehaviour
{
    public GameObject obstacleSpecialEffect;

    //Sound
    [SerializeField] AudioSource colloctObstacleSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(obstacleSpecialEffect,transform.position,Quaternion.identity);
            colloctObstacleSound.Play();
        }
    }

}
