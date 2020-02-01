

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ.Item
{
    [CreateAssetMenu(fileName = "Tool", menuName = "GGJ-Starry-2020/Tool", order = 0)]
    public class Tool : ScriptableObject
    {
        
        [SerializeField] protected int id;
        public int GetID()
        {
            return id;
        }
    }
}
