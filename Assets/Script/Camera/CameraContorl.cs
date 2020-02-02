using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorl : MonoBehaviour
{
    GameObject player;

    float[] yPosition = { 0, 2.4f, 6 };
    float cameraY;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(player.transform.position.y >= yPosition[1]) cameraY = yPosition[1];
        else if (player.transform.position.y >= yPosition[2]) cameraY = yPosition[2];
        else cameraY = yPosition[0];
        transform.position = new Vector3(player.transform.position.x, cameraY, transform.position.z);
    }
}
