using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.UI
{
    public class Door : MonoBehaviour
    {
        public void CloseDoor()
        {
            GetComponent<Animator>().SetTrigger("Close");
        }

        public void OpenDoor()
        {
            GetComponent<Animator>().SetTrigger("Open");
        }
    }

}