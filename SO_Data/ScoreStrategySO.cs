using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/ScoreStrategySO")]
public class ScoreStrategySO : ItemStrategy
{
    public int scoreAmount = 100;

    public override void ApplyEffect(playerMovement player, PlayerHealth health, ScoreManager scoreManager)
    {
        scoreManager.AddScore(scoreAmount);
    }
}
