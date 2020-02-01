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
        [SerializeField]container toolBar;
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
            if(Sinput.GetButtonDown("Submit")){
                problem.gameObject.GetComponent<container>().putIn(toolBar.TakeOut(toolBar.GetSelecter()));
                problem.checkAns(problem.gameObject.GetComponent<container>().GetTools());
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
                        problemUI.SetSlot(container.GetToolID(i),i);
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