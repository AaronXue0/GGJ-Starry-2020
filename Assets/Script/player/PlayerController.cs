using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Movement;
using GGJ.Repare;
using GGJ.Backpack;
namespace GGJ.Control{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private GameObject tool;
        [SerializeField]private GameObject pro;
   
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            InteractWithMovment();
            InteractWithElevator();
            InteractWithRepare();
            InteractWithToolSelecter();
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
        private void InteractWithToolSelecter(){
            container toolbar = GameObject.FindGameObjectWithTag("ToolBar").GetComponent<container>();
            if(Sinput.GetButtonDown("SelectLastTool")){
                toolbar.LastTool();
            }
            if (Sinput.GetButtonDown("SelectNextTool"))
            {
                toolbar.NextTool();
            }
           // if(Sinput.GetButtonDown("")){

            //}
        }
    }
}