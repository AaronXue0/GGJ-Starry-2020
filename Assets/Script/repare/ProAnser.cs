using UnityEngine;
using System.Collections.Generic;
using GGJ.Item;
namespace GGJ.Repare{
    [CreateAssetMenu(fileName = "ProAnser", menuName = "GGJ-Starry-2020/ProAnser", order = 0)]
    public class ProAnser : ScriptableObject {
        [SerializeField] List<Tool> tools;
        public bool CheckAns(List<Tool> items)
        {
            if(tools.Count!= items.Count) return false;
            for(int i=0;i<tools.Count;i++){
                if(tools[i].GetID()!=items[i].GetID()) return false;
            }

            return true;
        }
    }
}