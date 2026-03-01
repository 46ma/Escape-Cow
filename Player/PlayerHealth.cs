using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Setting")]
    [SerializeField] private int totalHeart = 3;
    public Image[] hearts;
    private Animator playerAnim;

    [SerializeField] private bool isDead = false;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Health calculation
    public void ChangeHealth(int amount)
    {
        if (isDead) return;

        totalHeart += amount;
        if (totalHeart > 3) totalHeart = 3; // Max Health

        if (amount < 0) playerAnim.SetTrigger("hurt"); // If take damage play hurt animation

        UpdateHeartsUI();

        if (totalHeart <= 0) Die();
    }

    // Update Health UI
    public void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < totalHeart);
        }
    }

    private void Die()
    {
        isDead = true;
        playerAnim.SetTrigger("dead");
        SceneManager.LoadScene("gameover");
    }

    public bool IsDead() => isDead;
}
