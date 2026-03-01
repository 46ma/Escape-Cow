using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemStrategy : ScriptableObject
{
    public abstract void ApplyEffect(playerMovement player , PlayerHealth health , ScoreManager scoreManager);
}
