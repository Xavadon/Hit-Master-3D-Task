using UnityEngine;

namespace OK
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health = 3;
        private float _maxHealth;

        [SerializeField] private GameObject _healthBarGameObject;
        private HealthBar _healthBar;

        public bool _isDead;

        private void Start()
        {
            _maxHealth = _health;
            _healthBar = _healthBarGameObject.GetComponent<HealthBar>();
        }

        public void EnemyHurt()
        {
            _health--;
            if (_health <= 0) EnemyDeath();

            _healthBar.SetHealth(_health, _maxHealth);
        }

        private void EnemyDeath()
        {
            _isDead = true;
            _healthBarGameObject.SetActive(false);
            GetComponentInParent<Level>().CheckEnemies();
            GetComponentInChildren<Animator>().enabled = false;
            GetComponentInChildren<AnimatorHandler>().enabled = false;
        }
    }
}
