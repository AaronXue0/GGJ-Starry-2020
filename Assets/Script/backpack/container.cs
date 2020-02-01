using UnityEngine;
using System.Collections.Generic;
using GGJ.Item;
namespace GGJ.Backpack{
    public class container : MonoBehaviour {
        [SerializeField] private List<Tool> tools;
        [SerializeField] private Tool currTool;
        [SerializeField] private int selecter;
        private void Start()
        {
            
        }
        private void Update()
        { 
            

        }
        public bool putIn(Tool tool){
            int index=0;
            for(index =0;index <tools.Count;index++){
                if(tools[index]==null) break;
            }
            if(index<tools.Count){
                tools[index] = tool;
                return true;
            }
            return false;
        }
        public Tool TakeOut(int index){
            Tool current = null;
            if(index>=0&&index<tools.Count){
                current = tools[index];
                tools[index] = null;
            }
            return current;
            
        }

        public Tool GetCurrentTool(){
            return tools[selecter];
        }
        public void NextTool(){
            selecter = Mathf.Min(selecter + 1,tools.Count-1);
        }
        public void LastTool()
        {
            selecter = Mathf.Max(selecter - 1, 0);
        }
        public int GetSelecter(){
            return selecter;
        }
    }
}