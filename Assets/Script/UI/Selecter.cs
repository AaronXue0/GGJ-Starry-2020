using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Backpack;
namespace GGJ.UI{
    public class Selecter : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void FixedUpdate() {
            SetSelecter();
        }
        private void SetSelecter(){
            GameObject toolBar  = GameObject.FindGameObjectWithTag("ToolBar");
            transform.position = toolBar.transform.GetChild(toolBar.GetComponent<container>().GetSelecter()).position;
            
        }
    }
}