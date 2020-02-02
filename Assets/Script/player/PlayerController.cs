using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Movement;
using GGJ.Repare;
using GGJ.Backpack;
using GGJ.Item;
using GGJ.UI;
namespace GGJ.Control{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]ProblemUI problemUI;
        [SerializeField]GameObject toolBar;
        Animator animator;
        bool isPicking;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            isPicking = false;
        }

        // Update is called once per frame
        void Update()
        {
            
            InteractWithMovment();
            InteractWithElevator();

            InteractWithToolSelecter();
            InteractWithItem();
            InteractWithMovment();
            InteractWithElevator();

            InteractWithPorblem();
            //InteractWIthPick();
        }
        private void InteractWithMovment(){
            if (isPicking) return;
            GetComponent<Mover>().ForceToMove(Sinput.GetVector("Horizontal", "", ""));
            if (Sinput.GetVector("Horizontal", "", "").x < 0) transform.localScale = new Vector3(1f, 1f, -1f);
            if (Sinput.GetVector("Horizontal", "", "").x > 0) transform.localScale = new Vector3(1f, 1f, 1f);
            transform.rotation = Quaternion.Euler(0, 95, 0);
            //animator.SetFloat("Run", Mathf.Abs(Sinput.GetVector("Horizontal", "", "").x));
        }
        private void InteractWithElevator()
        {
            if (Sinput.GetButtonDown("Up"))
            {
                GetComponent<Elevator>().Boost(Sinput.GetVector("", "Vertical", ""));
            }
            else if (Sinput.GetButtonDown("Down"))
            {
                GetComponent<Elevator>().Boost(Sinput.GetVector("", "Vertical", ""));
            }
        }
        private void Repare(Problem problem){
            
            if(Sinput.GetButtonDown("Submit"))
            {
                container proContainer = problem.gameObject.GetComponent<container>();
                container container = GetComponent<container>();
                proContainer.putIn(container.TakeOut(container.GetSelecter()));
                ChangeImg(container);
                problem.checkAns(proContainer.GetTools());
                
            
            }
            
        }

        private void ChangeImg(container container)
        {
          
            List<Tool> tools = container.GetTools();
            for (int i=0;i<tools.Count;i++ )
            {
                toolBar.transform.GetChild(i).GetComponent<ToolSlot>().SetItemImage(tools[i]);
                i++;
            } 
        }

        private void InteractWithPorblem(){
            Ray ray = new Ray(transform.position, Vector3.back * 100);
            
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 10))
            {
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.GetComponent<Problem>() != null)
                {
                    container container = hitObj.GetComponent<container>();
                    
                    for (int i=0; i < container.GetSize();i++){
                        problemUI.SetSlot(container.GetTool(i),i);
                    }
                    problemUI.ActiveSlots(container.GetSize());
                    Repare(hitObj.GetComponent<Problem>());
                    return;
                }
            }
            problemUI.HideSlots();
        }
        private void InteractWithToolSelecter()
        {
            container toolbar = GetComponent<container>();
            if (Sinput.GetButtonDown("SelectLastTool"))
            {
                toolbar.LastTool();
            }
            if (Sinput.GetButtonDown("SelectNextTool"))
            {
                toolbar.NextTool();
            }
        }

        

        private void InteractWithItem(){
            if(Sinput.GetButtonDown("Submit")){
                Ray ray = new Ray(transform.position,Vector3.forward*100);
                
                RaycastHit hit;
                container container = GetComponent<container>();
                if(Physics.Raycast(ray, out hit, 10)){
                   
                    if(hit.collider.gameObject.GetComponent<Pickable>()!=null){
                        Tool pickupItem = hit.collider.gameObject.GetComponent<Pickable>().PickUp();
                        
                        if(container.putIn(pickupItem)){
                            
                            Destroy(hit.collider.gameObject);
                            ChangeImg(container);
                        }
                        else{
                            Debug.Log("full pack");
                        }
                        
                    }
                }
            }
        }

        private void InteractWIthPick()
        {
            if (Sinput.GetButtonDown("Submit") && !isPicking)
            {
                isPicking = true;
                animator.SetTrigger("Pick");
                StartCoroutine(Picking());
            }
        }
        IEnumerator Picking()
        {
            yield return new WaitForSeconds(1.1f);
            isPicking = false;
        }


    }
}