using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/SpeedStrategySO")]
public class SpeedStrategySO : ItemStrategy
{
    public float boostAmount = 5f;
    public float duration = 1.5f;

    public override void ApplyEffect(playerMovement player, PlayerHealth health, ScoreManager scoreManager)
    {
        player.BoostSpeed(boostAmount, duration);
    }
}
