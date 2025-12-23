using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stop all animation when player die
public class PlayerStopAnim : MonoBehaviour
{
    private Animator playermatStopAnim;
    void Awake()
    {
        playermatStopAnim = GetComponent<Animator>();
    }

    public void playyerMatStomAnim()
    {
        playermatStopAnim.enabled = false;
    }
}
