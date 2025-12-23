using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//สคิร์ปนี้ใส่ใน empty ที่ชื่อ bttController
public class BttControl : MonoBehaviour
{
    [SerializeField] private intSo scoreSO; //scripttable Oject for collect score

    //Reset score when player push try again button
    public void tryAgain()
    {
        
            resetPlayerScore();
            SceneManager.LoadScene("level_1 The Road");
        
    }

    //Quit game
    public void quitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }

    //Main menu
    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void resetPlayerScore() //Reset scoreSO
    {
        scoreSO.Value = 0 ;
    }
}
