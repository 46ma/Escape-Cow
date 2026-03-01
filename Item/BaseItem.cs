using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public ItemStrategy itemSO;
    public GameObject effectPrefab;
    public AudioSource sound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerMovement playerMovement = collision.gameObject.GetComponent<playerMovement>();
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        ScoreManager scoreManager = collision.gameObject.GetComponent<ScoreManager>();

        if (itemSO != null)
        {
            itemSO.ApplyEffect(playerMovement, playerHealth, scoreManager);
        }

        if (sound) sound.Play();

        if (effectPrefab) Instantiate(effectPrefab,transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
