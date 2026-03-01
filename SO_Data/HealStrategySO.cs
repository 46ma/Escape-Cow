using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HealStrategySO")]
public class HealStrategySO : ItemStrategy
{
    public int healAmount;

    public override void ApplyEffect(playerMovement player, PlayerHealth health, ScoreManager scoreManager)
    {
        health.ChangeHealth(healAmount);
    }
}
