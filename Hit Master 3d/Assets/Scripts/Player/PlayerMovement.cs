using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace OK
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _wayPoints;
        [SerializeField] private float _accuracy = 0.1f;
        private int _currentPoint = 0;

        private NavMeshAgent _navMeshAgent;
        private AnimatorHandler _animatorHandler;
        private Player _player;

        private void Start()
        {
            transform.position = _wayPoints[0].position;

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = GetComponent<Player>();
            _animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        private void Update()
        {
            _animatorHandler.UpdateAnimatorValues(_navMeshAgent.velocity);

            if (!_player._canMove || !_player._isGameStarted) return;

            Transform target = _wayPoints[_currentPoint];
            _navMeshAgent.SetDestination(target.position);

            if (Vector3.Distance(transform.position, target.position) <= _accuracy)
            {
                _currentPoint++;
                if (_currentPoint >= _wayPoints.Length)
                {
                    SceneManager.LoadScene("GameScene");
                }
            }
        }
    }
}
