using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.UI
{
    public class Magnifier : MonoBehaviour
    {
        Door door;

        private void Start()
        {
            door = FindObjectOfType<Door>();
        }

        public void Touched()
        {
            Debug.Log(1);
            GameObject player = GameObject.Find("Player");
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1)
            {
                door.CloseDoor();
                Destroy(gameObject);
            }
        }
    }

}