using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.UI
{
    public class Magnifier : MonoBehaviour
    {
        [SerializeField]
        GameObject doorObject;

        Door door;

        private void Start()
        {
            door = doorObject.GetComponent<Door>();
        }

        public void Touched()
        {
            GameObject player = GameObject.Find("Player");
            if (Mathf.Abs(Vector2.Distance(transform.position, player.transform.position)) < 1)
            {
                door.OpenDoor();
                Destroy(gameObject);
            }
        }
    }

}