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
        [SerializeField]private Tool _tool;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void FixImage(){
            if(_tool==null) gameObject.GetComponent<Image>().sprite =Resources.Load<Sprite>("UI/Skin/UISprite.psd");
            else gameObject.GetComponent<Image>().sprite = _tool.img;
        }
        public void SetItemImage(Tool tool){
            if(tool!=null){
                gameObject.GetComponent<Image>().sprite = tool.img;
                _tool = tool;
            }
            else{
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Skin/UISprite.psd");
                _tool = null;
            }
        }
        
    }
}