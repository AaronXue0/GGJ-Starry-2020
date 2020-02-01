using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ.Item{
    public class Pickable : MonoBehaviour
    {
        [SerializeField]Tool tool;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public Tool PickUp(){
            
            return tool;
        }
    }
}
