using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Repare;
using GGJ.Item;
namespace GGJ.UI{
    public class ProblemUI : MonoBehaviour
    {
        [SerializeField]private GameObject slot;
        // Start is called before the first frame update

        private void Awake(){ 
            HideSlots();
        }

        // Update is called once per frame
        void Update()
        {
           
        }
        public void SetSlot(Tool tool,int index){
            transform.GetChild(index).GetComponent<ToolSlot>().SetItemImage(tool);
        }
        public void ActiveSlots(int count){
            for(int i=0;i<count;i++)
                transform.GetChild(i).gameObject.SetActive(true);
            gameObject.SetActive(true);
            
        }
        public void HideSlots()
        {
            gameObject.SetActive(false);
            for (int i = 0; i < transform.GetChildCount(); i++)
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}