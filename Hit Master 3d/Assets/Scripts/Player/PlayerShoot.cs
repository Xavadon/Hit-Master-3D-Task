using System.Collections;
using UnityEngine;

namespace OK
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _shootPoint;

        private GameObject[] _pool;
        [SerializeField] private int _poolAmount = 10;
        private int _poolCounter = 0;

        [SerializeField] private float _bulletSpeed = 10;
        [SerializeField] private float _shootCooldown = 0.4f;
        private bool _isCooldown;

        private AnimatorHandler _animatorHandler;
        private Player _player;
        private Camera _camera;

        private Vector3 _hitPoint;

        private void Start()
        {
            SpawnPool();
            _player = GetComponent<Player>();
            _animatorHandler = GetComponentInChildren<AnimatorHandler>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Attack") && _player._canAttack && !_isCooldown)
            {
                RaycastHit hit;
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit, 200)) _hitPoint = hit.point;
                else return;

                if (hit.transform.gameObject.TryGetComponent<Player>(out Player player)) return;

                SpawnBullet();
                StartCoroutine(nameof(AttackCooldown));
                _animatorHandler.PlayTargetAnimation("Attack", 0.2f);
            }
        }

        private void SpawnPool()
        {
            _pool = new GameObject[_poolAmount];
            for (int i = 0; i < _poolAmount; i++)
            {
                _pool[i] = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
                _pool[i].SetActive(false);
                Debug.Log(_pool[i]);
            }
        }

        private IEnumerator AttackCooldown()
        {
            _isCooldown = true;
            yield return new WaitForSeconds(_shootCooldown);
            _isCooldown = false;
        }

        public void SpawnBullet()
        {
            //GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            GameObject bullet = _pool[_poolCounter];
            bullet.transform.position = _shootPoint.position;
            bullet.SetActive(true);

            Vector3 direction = _hitPoint - bullet.transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * _bulletSpeed, ForceMode.Impulse);

            _poolCounter++;

            if (_poolCounter > _pool.Length - 1) _poolCounter = 0;
        }
    }
}
