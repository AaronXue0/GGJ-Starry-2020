using UnityEngine;
namespace GGJ.Repare{
    public class User : MonoBehaviour {
        public void UseTool(Transform tool,Transform problem){
                tool.position = problem.position;
                tool.rotation = problem.rotation;
                
                Debug.Log("reparing");  
        }   
    }
}