using UnityEngine;
namespace GGJ.Movement{
    public class Mover : MonoBehaviour {
        [SerializeField] private float speed;
        public void ForceToMove(Vector3 vector){
            GetComponent<Rigidbody>().velocity = vector * speed;
        }
    }
}