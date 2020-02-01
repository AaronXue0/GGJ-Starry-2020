using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Movement;
namespace GGJ.Control{
    public class PlayerController : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            InteractWithMovment();
            InteractWithElevator();
        }
        private void InteractWithMovment(){
            GetComponent<Mover>().ForceToMove(Sinput.GetVector("Horizontal", "", ""));
        }
        private void InteractWithElevator()
        {
            GetComponent<Elevator>().Boost(Sinput.GetVector("", "Vertical", ""));
        }
    }
}