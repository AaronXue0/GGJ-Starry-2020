using UnityEngine;
namespace GGJ.Item{
    public class Door : MonoBehaviour {
        [SerializeField] private Quaternion angle;
        private void Update()
        {
            //Open();
        }
        public void Open(){
            GetComponent<Animator>().SetBool("IsOpen",true);
            //transform.rotation = angle;
        }
        public void Close()
        {
            GetComponent<Animator>().SetBool("IsOpen", false);
            //transform.rotation = angle;
        }
    }
}