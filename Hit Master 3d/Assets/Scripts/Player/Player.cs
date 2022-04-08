using UnityEngine;

namespace OK
{
    public class Player : MonoBehaviour
    {
        public bool _canMove = true;
        public bool _canAttack = false;
        public bool _isGameStarted = false;

        public static Player _singleton { get; private set; }

        private void Awake()
        {
            _singleton = this;
        }

        private void Update()
        {
            if (Input.GetButton("Attack") && !_isGameStarted)
            {
                _isGameStarted = true;
            }
        }
    }
}
