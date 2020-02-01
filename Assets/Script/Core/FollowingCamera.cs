using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ.Core{
    public class FollowingCamera : MonoBehaviour
    {
        [SerializeField]Transform target;
        private void Update()
        {
            transform.position = target.position;
        }
        private void FixedUpdate() {
            
        }
    }
}