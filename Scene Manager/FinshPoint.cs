using UnityEngine;

public class FinshPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player"))
        {
            // go to next level
            SceneController.instance.NextLevel();
        }
    }

}