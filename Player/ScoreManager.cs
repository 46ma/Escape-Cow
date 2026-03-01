using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Setting")]
    [SerializeField] intSo ScoreSO;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private int totalStudentCard;
    public studentCard studentCardCounter;

    private playerMovement player;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        player = GetComponent<playerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        UpdateScoreUI();
    }

    // ItemStrategy
    public void ProcessItem(ItemStrategy strategy)
    {
        strategy.ApplyEffect(player, playerHealth , this);
    }

    // Update Score
    public void AddScore(int amount)
    {
        ScoreSO.Value += amount;
        UpdateScoreUI();
    }

    // Update Student Card and Score
    public void AddStudentCrad(int amount , int score)
    {
        totalStudentCard += amount;
        AddScore(500); // Student card score
        studentCardCounter.showStudentCard(totalStudentCard);
    }

    //Update Score UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + ScoreSO.Value.ToString();
    }
}
