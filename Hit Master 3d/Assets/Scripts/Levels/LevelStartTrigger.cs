using UnityEngine;

namespace OK
{
    public class LevelStartTrigger : MonoBehaviour
    {
        private Level _level;

        private void Start()
        {
            _level = GetComponentInParent<Level>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                _level.StartLevel();
            }
        }
    }
}
