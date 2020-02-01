using UnityEngine;
using System.Collections.Generic;
using GGJ.Item;
namespace GGJ.Repare{
    public class Problem : MonoBehaviour {
        [SerializeField]ProAnser anser;
        public bool checkAns(List<Tool> tools){
            if(anser.CheckAns(tools)){
                Destroy(gameObject);
            }
            return anser.CheckAns(tools);
        }

    }
}