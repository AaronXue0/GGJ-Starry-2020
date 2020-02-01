using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            
        }
        public void SetItemImage(Tool tool){
            if(tool!=null)
                gameObject.GetComponent<Image>().sprite = tool.img;
            

        }
        
    }
}