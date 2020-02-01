using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Movement
{
    public class Elevator : MonoBehaviour
    {
        public bool isCollidredBottom;//Collidered Elevator or not.
        public bool isCollidredMiddle;//Collidered Elevator or not.
        public bool isCollidredTop;//Collidered Elevator or not.

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            Ray ray = new Ray(transform.position, transform.forward * 100);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10))
            {
                //Do Something.
                Debug.Log(hit.collider.gameObject.tag);
                if(hit.collider.gameObject.tag == "ElevatorBottom")
                {
                    isCollidredBottom = true;
                }
            }
            else
            {
                Reset();
            }
        }

        private void Reset()
        {
            isCollidredBottom = false;
            isCollidredMiddle = false;
            isCollidredTop = false;
        }

        public void Boost(Vector3 movement)
        {
            if (isCollidredBottom) Debug.Log("y");
            if (isCollidredBottom && movement != Vector3.zero)
            {
                Debug.Log(1);
                if(movement.y > 0)
                {
                    Transform floor = GameObject.Find("2F").transform;
                    transform.position = new Vector3(transform.position.x, floor.position.y + transform.localScale.y * 1.1f, transform.position.z);
                }
            } 
        }
    }
}
