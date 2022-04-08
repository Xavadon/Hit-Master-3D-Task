using UnityEngine;

namespace OK
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorHandler : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void UpdateAnimatorValues(Vector3 velocity)
        {
            Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);
            float hVelocity = horizontalVelocity.magnitude;

            _animator.SetFloat("Velocity", hVelocity, 0.1f, Time.deltaTime);
        }

        public void PlayTargetAnimation(string name, float transitionTime)
        {
            _animator.CrossFade(name, transitionTime);
        }
    }
}
