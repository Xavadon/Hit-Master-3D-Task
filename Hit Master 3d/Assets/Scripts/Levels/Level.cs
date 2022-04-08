using UnityEngine;

namespace OK
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject[] Enemies;

        private Player _player;

        private void Start()
        {
            _player = Player._singleton;
        }

        public void StartLevel()
        {
            _player._canMove = false;
            _player._canAttack = true;
        }

        public void CheckEnemies()
        {
            int enemyCounter = Enemies.Length;
            Debug.Log(enemyCounter);

            for (int i = 0; i < Enemies.Length; i++)
                if(Enemies[i].GetComponent<Enemy>()._isDead) enemyCounter--;
            Debug.Log(enemyCounter);
            if(enemyCounter == 0) EndLevel();
            else enemyCounter = Enemies.Length;
        }

        private void EndLevel()
        {
            _player._canMove = true;
            _player._canAttack = false;
        }
    }
}
