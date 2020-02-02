using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorl : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+1, transform.position.z);
    }
}
