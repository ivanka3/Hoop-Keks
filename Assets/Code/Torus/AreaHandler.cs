using Code.States;
using UnityEngine;

namespace Code.Torus
{
    public class AreaHandler : MonoBehaviour
    {
        [SerializeField] private Torus _torus;
        [SerializeField] private BoxCollider2D _torusAreaCollider;
        [SerializeField] private CircleCollider2D _ballAreaCollider;

        private void Start()
        {
            _ballAreaCollider = LevelStateHandler.Instance.Ball.AreaCollider;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == _ballAreaCollider)
            {
                _torus.UnlockGoal();
            }
        }
    }
}