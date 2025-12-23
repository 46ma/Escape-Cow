using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControl : MonoBehaviour
{
    private float length, startPos; //ตัวแปรเก็บความกว้าง
    public float parallaxFector; //เก็บตัวแปรความเร็วเคลื่อนที่ตามกล้อง มีค่าตั้งแต่ 0-1
    public GameObject cam; //Main camera
    void Start()
    {
        startPos = transform.position.x; //startPos เก็บ x เริ่มต้น
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Background's length
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxFector; //distance form the camera
        transform.position = new Vector3(startPos + distance,transform.position.y,transform.position.z); //Tranform follow the camera

        float temp = cam.transform.position.x * (1 - parallaxFector); //temp is the distance between camera and background
        if (temp > startPos+length)
        {
            startPos+=length;
        }
        else if (temp < startPos-length)
        {
            startPos-=length;
        }
    }
}
