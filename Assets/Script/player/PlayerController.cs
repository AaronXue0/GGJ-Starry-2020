using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Movement;
namespace GGJ.Control{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            InteractWithMovment();
        }
        private void InteractWithMovment(){
            GetComponent<Mover>().ForceToMove(Sinput.GetVector("Horizontal","",""));
        }
    }
}