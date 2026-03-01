using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/SignStrategySO")]
public class SignStrategySO : ItemStrategy
{
    public float stunDuration = 2.0f;

    public override void ApplyEffect(playerMovement player, PlayerHealth health, ScoreManager scoreManager)
    {
        player.StunPlayer(stunDuration);
    }
}
