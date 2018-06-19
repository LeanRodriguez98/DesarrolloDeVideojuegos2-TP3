using UnityEditor;
using UnityEngine;
// HACER UN CODIGO DE MOVIMIENTO PROPIO; ESTE NO SIRVE
namespace DVJ02.Clase08
{
    public class PlayerController : MonoBehaviour
    {
        private bool moving;
        protected Rigidbody rig;
        public float speed;
        private char lastKey;
        void Start()
        {
            rig = GetComponent<Rigidbody>();
        }

        void Update()
        { 
            Move();
        }

        private void Move()
        {
            float vertical = Input.GetAxis("Vertical");
            transform.Translate(0, 0, vertical*speed);
            float horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0, horizontal, 0);
        }
    }
}
