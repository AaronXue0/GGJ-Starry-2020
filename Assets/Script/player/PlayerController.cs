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
        Animator animator;
        bool isPicking;
        bool isElevating;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            isPicking = false;
            isElevating = false;
        }
        // Update is called once per frame
        void Update()
        {
            if (isPicking || isElevating)
            {
                return;
            }
            InteractWithMovment();
            InteractWithElevator();
            //InteractWithRepare();
            //InteractWithToolSelecter();
            //InteractWithItem();
            InteractWithMovment();
            InteractWithElevator();
            //InteractWithRepare();
            InteractWIthPick();
        }
        private void InteractWithMovment()
        {
            GetComponent<Mover>().ForceToMove(Sinput.GetVector("Horizontal", "", ""));
            if (Sinput.GetVector("Horizontal", "", "").x < 0) transform.localScale = new Vector3(1f, 1f, -1f);
            if (Sinput.GetVector("Horizontal", "", "").x > 0) transform.localScale = new Vector3(1f, 1f, 1f);
            transform.rotation = Quaternion.Euler(0, 95, 0);
            animator.SetFloat("Run", Mathf.Abs(Sinput.GetVector("Horizontal", "", "").x));
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
        //private void InteractWithRepare(){
        //    if(Sinput.GetButtonDown("Use")){
        //        GetComponent<User>().UseTool(tool.transform,pro.transform);
        //    }
        //}
        //private void InteractWithToolSelecter()
        //{
        //    container toolbar = GetCotainer();
        //    if (Sinput.GetButtonDown("SelectLastTool"))
        //    {
        //        toolbar.LastTool();
        //    }
        //    if (Sinput.GetButtonDown("SelectNextTool"))
        //    {
        //        toolbar.NextTool();
        //    }
        //}

        //private static container GetCotainer()
        //{
        //    return GameObject.FindGameObjectWithTag("ToolBar").GetComponent<container>();
        //}

        //private void InteractWithItem(){
        //    if(Sinput.GetButtonDown("Submit")){
        //        Ray ray = new Ray(transform.position,Vector3.forward*100);
        //        Debug.DrawRay(transform.position, Vector3.forward*100,Color.red);
        //        RaycastHit hit;
        //        container container = GetCotainer();
        //        if(Physics.Raycast(ray, out hit, 10)){
                   
        //            if(hit.collider.gameObject.GetComponent<Pickable>()!=null){
        //                if(container.putIn(hit.collider.gameObject.GetComponent<Pickable>().PickUp()))
        //                    Destroy(hit.collider.gameObject);
        //                else{
        //                    Debug.Log("full pack");
        //                }
                        
        //            }
        //        }
        //    }
        //}
        public void SetElevatorState(bool state)
        {
            isElevating = state;

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