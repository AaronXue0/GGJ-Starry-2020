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
            InteractWithRepare();
            InteractWIthPick();
        }
        private void InteractWithMovment(){
            if (isPicking) return;
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
        private void InteractWithRepare(){
            if(Sinput.GetButtonDown("Use")){
                GetComponent<User>().UseTool(tool.transform,pro.transform);
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