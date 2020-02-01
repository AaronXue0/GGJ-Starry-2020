using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Movement;
using GGJ.Repare;
using GGJ.Backpack;
using GGJ.Item;
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
            InteractWithItem();
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
        private void InteractWithToolSelecter()
        {
            container toolbar = GetCotainer();
            if (Sinput.GetButtonDown("SelectLastTool"))
            {
                toolbar.LastTool();
            }
            if (Sinput.GetButtonDown("SelectNextTool"))
            {
                toolbar.NextTool();
            }
        }

        private static container GetCotainer()
        {
            return GameObject.FindGameObjectWithTag("ToolBar").GetComponent<container>();
        }

        private void InteractWithItem(){
            if(Sinput.GetButtonDown("Submit")){
                Ray ray = new Ray(transform.position,Vector3.forward*100);
                Debug.DrawRay(transform.position, Vector3.forward*100,Color.red);
                RaycastHit hit;
                container container = GetCotainer();
                if(Physics.Raycast(ray, out hit, 10)){
                   
                    if(hit.collider.gameObject.GetComponent<Pickable>()!=null){
                        if(container.putIn(hit.collider.gameObject.GetComponent<Pickable>().PickUp()))
                            Destroy(hit.collider.gameObject);
                        else{
                            Debug.Log("full pack");
                        }
                        
                    }
                }
            }
        }
    }
}