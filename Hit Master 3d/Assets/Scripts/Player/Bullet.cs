using UnityEngine;

namespace OK
{
    public class Bullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.EnemyHurt();
            }
        }
    }
}
