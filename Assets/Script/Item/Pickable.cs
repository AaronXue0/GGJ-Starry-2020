using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ.Item{
    public class Pickable : MonoBehaviour
    {
        [SerializeField]Tool tool;
        
        public Tool PickUp(){
            
            return tool;
        }
    }
}
