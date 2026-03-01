using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    [Header("Stat Settings")]
    public float moveSpeed = 3f;
    public int damageAmount = 1;

    // Check original sprite facing
    [Tooltip("Checked if current sprite is facing left")]
    public bool isOriginallyFacingLeft;

    [Header("Visual Settings")]
    public Vector3 localScaleValue = new Vector3(0.4f, 0.4f, 0.4f); // For fliping
}
