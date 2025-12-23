using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreCounter : MonoBehaviour //Show score that be scripttable Object
{
    [SerializeField] intSo scoreSO; //Score collector
    public TextMeshProUGUI scoreText; //UI text
    
    void Awake()
    {
        scoreText.text = "Your score is " + scoreSO.Value.ToString(); //Show score in scripttable Object
    }

}
