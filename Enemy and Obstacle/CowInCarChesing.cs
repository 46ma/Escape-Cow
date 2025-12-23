using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowInCarChesing : MonoBehaviour
{
    public GameObject targetPos;
    [SerializeField] float cowSpeed;

    private float Distance;

void Update()
    {
        //Make this gameObject go to target position
        Distance = Vector2.Distance(transform.position, targetPos.transform.position);  
        Vector2 distance = targetPos.transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, targetPos.transform.position, cowSpeed * Time.deltaTime); //ให้เคลื่อนที่ไปหาจุดหมายด้วยความเร็วของศัตรู

    }
}
