using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Control;

namespace GGJ.Movement
{
    public class Elevator : MonoBehaviour
    {
        PlayerController controller;

        [SerializeField]
        GameObject elevator1f;
        [SerializeField]
        GameObject elevator2f;
        [SerializeField]
        GameObject elevator3f;
        [SerializeField]
        string floor1;
        [SerializeField]
        string floor2;
        [SerializeField]
        string floor3;

        public bool isCollidredBottom;//Collidered Elevator or not.
        public bool isCollidredMiddle;//Collidered Elevator or not.
        public bool isCollidredTop;//Collidered Elevator or not.

        private void Start()
        {
            Reset();
            controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y +1f, transform.position.z), Vector3.forward * 5);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10))
            {
                if (hit.collider.gameObject.tag == "ElevatorBottom")
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
                    Transform floor = GameObject.Find(floor2).transform;
                    elevator2f.GetComponent<Animator>().SetTrigger("Open");
                    EnterElevator(elevator1f.transform, floor);
                    StartCoroutine(DelayExit2F());
                }
            }
            else if (isCollidredMiddle)
            {
                if(movement.y > 0)
                {
                    Transform floor = GameObject.Find(floor3).transform;
                    elevator2f.GetComponent<Animator>().SetTrigger("Open");
                    EnterElevator(elevator2f.transform, floor);
                    StartCoroutine(DelayExit3F());
                }
                else if(movement.y < 0)
                {
                    Transform floor = GameObject.Find(floor1).transform;
                    elevator2f.GetComponent<Animator>().SetTrigger("Open");
                    EnterElevator(elevator2f.transform, floor);
                    StartCoroutine(DelayExit1F());
                }
            }
            else if (isCollidredTop)
            {
                Transform floor = GameObject.Find(floor2).transform;
                elevator3f.GetComponent<Animator>().SetTrigger("Open");
                EnterElevator(elevator3f.transform, floor);
                StartCoroutine(DelayExit2F());
            }
        }

        void EnterElevator(Transform floor, Transform targetFloor)
        {
            transform.rotation = Quaternion.Euler(0f, 180f,0f);
            controller.SetElevatorState(true);
            StartCoroutine(DelayEnter(floor, targetFloor));
        }

        private void MovePlayer(Transform floor)
        {
            transform.position = new Vector3(transform.position.x, floor.position.y, transform.position.z);
            Reset();
        }

        IEnumerator DelayEnter(Transform floor, Transform targetFloor)
        {
            yield return new WaitForSeconds(1f);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     new Vector3(floor.position.x, transform.position.y, floor.position.z + 5f),
                                                     10);
            floor.gameObject.GetComponent<Animator>().SetTrigger("Close");
            MovePlayer(targetFloor);
        }

        IEnumerator DelayExit1F()
        {
            yield return new WaitForSeconds(2f);
            elevator1f.GetComponent<Animator>().SetTrigger("Open");
            yield return new WaitForSeconds(1f);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     new Vector3(transform.position.x, transform.position.y, -1f),
                                                     10);
            yield return new WaitForSeconds(0.5f);
            elevator1f.GetComponent<Animator>().SetTrigger("Close");
            controller.SetElevatorState(false);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        IEnumerator DelayExit2F()
        {
            yield return new WaitForSeconds(2f);
            elevator2f.GetComponent<Animator>().SetTrigger("Open");
            yield return new WaitForSeconds(1f);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     new Vector3(transform.position.x, transform.position.y, -1f),
                                                     10);
            yield return new WaitForSeconds(0.5f);
            elevator2f.GetComponent<Animator>().SetTrigger("Close");
            controller.SetElevatorState(false);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        IEnumerator DelayExit3F()
        {
            yield return new WaitForSeconds(2f);
            elevator3f.GetComponent<Animator>().SetTrigger("Open");
            yield return new WaitForSeconds(1f);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     new Vector3(transform.position.x, transform.position.y, -1f),
                                                     10);
            yield return new WaitForSeconds(0.5f);
            elevator3f.GetComponent<Animator>().SetTrigger("Close");
            controller.SetElevatorState(false);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
