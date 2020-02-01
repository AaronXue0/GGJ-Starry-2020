using UnityEngine;
using System.Collections.Generic;
using GGJ.Item;
namespace GGJ.Backpack{
    public class container : MonoBehaviour {
        [SerializeField] private List<Tool> tools;
        [SerializeField] private Tool currTool;
        
        private void Start()
        {

        }
        private void Update()
        {
            if(Sinput.GetButtonDown("tackout")){
                int i=0;
                while(i<tools.Count&&TakeOut(i)!=null) i++;
            }
            if (Sinput.GetButtonDown("putin"))
            {
                Debug.Log(putIn(currTool));
                
            }

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

    }
}