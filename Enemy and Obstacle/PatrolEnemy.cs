using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [Header("Data Reference")]
    public EnemyDataSO data;

    [Header("Patrol Points")]
    public Transform posA;        // Start Position
    public Transform posB;        // End Position
    private Vector3 targetPos;

    [Header("VFX & SFX")]
    public GameObject impactEffect;
    [SerializeField] private AudioSource impactSound;

    void Start()
    {
        targetPos = posA.position;
        Flip(targetPos.x > transform.position.x);
    }

    void Update()
    {
        //Move to target pos
        transform.position = Vector3.MoveTowards(transform.position, targetPos, data.moveSpeed * Time.deltaTime);

        //Change to new target pos when move to current target pos
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            if (targetPos == posA.position)
            {
                targetPos = posB.position;
            }
            else
            {
                targetPos = posA.position;
            }

            //Face the in the same direction
            Flip(targetPos.x > transform.position.x);
        }
    }

    private void Flip(bool faceRight)
    {
        Vector3 scale = data.localScaleValue; // SO Data
        float baseScaleX = Mathf.Abs(scale.x);

        // Facing condition
        if (data.isOriginallyFacingLeft)
        {
            scale.x = faceRight ? -baseScaleX : baseScaleX;
        }
        else
        {
            scale.x = faceRight ? baseScaleX : -baseScaleX;
        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
            {
                //Damage Calculation
                health.ChangeHealth(-data.damageAmount);
            }

            //Effect
            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }

            //Sound
            if (impactSound != null)
            {
                impactSound.Play();
            }
        }
    }
}
