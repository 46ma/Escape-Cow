using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class studentCard : MonoBehaviour
{
    public TextMeshProUGUI studentCardText;
    private int studentCardCount;

    void Start()
    {
        studentCardCount = 0;
        UpdateStudentCardText();
    }

    //Update Student card UI
    void UpdateStudentCardText()
    {
        Debug.Log("Test");
        studentCardText.text = studentCardCount.ToString() + " / 3";
        
    }

    //Show student card
    public void showStudentCard(int amount)
    {
        studentCardCount = amount;
        UpdateStudentCardText();
    }
}
