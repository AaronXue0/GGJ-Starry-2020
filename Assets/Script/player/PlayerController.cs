using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Movement;
using GGJ.Repare;
namespace GGJ.Control{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private GameObject tool;
        [SerializeField]private GameObject pro;
        [SerializeField]private Vector3 vectical;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            vectical  = Sinput.GetVector("", "Vertical", "");
            InteractWithMovment();
            InteractWithElevator();
            InteractWithRepare();
        }
        private void InteractWithMovment(){
            GetComponent<Mover>().ForceToMove(Sinput.GetVector("Horizontal", "", ""));
        }
        private void InteractWithElevator()
        {
            GetComponent<Elevator>().Boost(Sinput.GetVector("", "Vertical", ""));
        }
        private void InteractWithRepare(){
            if(Sinput.GetButtonDown("Use")){
                GetComponent<User>().UseTool(tool.transform,pro.transform);
   
            }
        }
    }
}