﻿using System.Collections;
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
                if (hit.collider.gameObject.tag == "ElevatorMiddle")
                {
                    isCollidredMiddle = true;
                }
                if (hit.collider.gameObject.tag == "ElevatorTop")
                {
                    isCollidredTop = true;
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
            if (isCollidredBottom && movement != Vector3.zero)
            {
                if(movement.y > 0)
                {
                    Transform floor = GameObject.Find("2F").transform;
                    MovePlayer(floor);
                }
            }
            else if (isCollidredMiddle)
            {
                if(movement.y > 0)
                {
                    Debug.Log(1);
                    Transform floor = GameObject.Find("3F").transform;
                    MovePlayer(floor);
                }
                else if(movement.y < 0)
                {
                    Debug.Log(2);
                    Transform floor = GameObject.Find("1F").transform;
                    MovePlayer(floor);
                }
            }
            else if (isCollidredTop)
            {
                Debug.Log(3);
                Transform floor = GameObject.Find("2F").transform;
                MovePlayer(floor);
            }
        }

        private void MovePlayer(Transform floor)
        {
            transform.position = new Vector3(transform.position.x, floor.position.y + transform.localScale.y * 1.1f, transform.position.z);
        }
    }
}