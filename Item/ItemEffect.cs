using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    //Effect
    public GameObject effect;

    //Sound
    [SerializeField] AudioSource itemSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(effect,transform.position,Quaternion.identity);
            itemSound.Play();
        }
    }
}
