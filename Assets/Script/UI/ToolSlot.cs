using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Backpack;
using GGJ.Item;

namespace GGJ.UI{
    public class ToolSlot : MonoBehaviour
    {
        [SerializeField]private int slotID;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            GetItemImage();
        }
        private void GetItemImage(){
            int id = GetComponentInParent<container>().GetToolID(slotID);        
            //getimage
        }
        private void GetSelector(){
            int id = GetComponentInParent<container>().GetSelecter();
            if(id == slotID){
                //slot onSelect
            }
        }
    }
}