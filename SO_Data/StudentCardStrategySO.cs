using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/StudentCardStrategySO")]
public class StudentCardStrategySO : ItemStrategy
{
    public int studentCardScore = 500;
    public int studentCardAmount = 1;

    public override void ApplyEffect(playerMovement player, PlayerHealth health, ScoreManager scoreManager)
    {
        scoreManager.AddStudentCrad(studentCardAmount, studentCardScore);
    }
}
