using UnityEngine;
using System.Collections.Generic;
using GGJ.Item;
namespace GGJ.Repare{
    public class Problem : MonoBehaviour {
        [SerializeField]ProAnser anser;
        public bool checkAns(List<Tool> tools){
            //Debug.Log("check");
            if(anser.CheckAns(tools)){
                //Debug.Log("true");
                Destroy(gameObject);
            }
            return anser.CheckAns(tools);
        }

    }
}