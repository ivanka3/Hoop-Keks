using UnityEngine;

namespace Code
{
    public class WallColliderCreator : MonoBehaviour
    {
        public float _colDepth = 4f;
        public float _zPosition = 0f;
        [SerializeField] private float _topPadding;
        [SerializeField] private float _botPadding;
        [SerializeField] private float _padding;
        
        private Vector2 _screenSize;
        private Transform _topCollider;
        private Transform _bottomCollider;
        private Transform _leftCollider;
        private Transform _rightCollider;

        private Vector3 _cameraPos;

        private void Start()
        {
            _topCollider = new GameObject().transform;
            _bottomCollider = new GameObject().transform;
            _rightCollider = new GameObject().transform;
            _leftCollider = new GameObject().transform;
 
            _topCollider.name = "TopCollider";
            _bottomCollider.name = "BottomCollider";
            _rightCollider.name = "RightCollider";
            _leftCollider.name = "LeftCollider";

            _topCollider.gameObject.AddComponent<BoxCollider2D>();
            _bottomCollider.gameObject.AddComponent<BoxCollider2D>();
            _rightCollider.gameObject.AddComponent<BoxCollider2D>();
            _leftCollider.gameObject.AddComponent<BoxCollider2D>();

            _topCollider.parent = transform;
            _bottomCollider.parent = transform;
            _rightCollider.parent = transform;
            _leftCollider.parent = transform;

            var camera = Camera.main;
            _cameraPos = Camera.main.transform.position;
            _screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)),
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -10))) * 0.5f;
            _screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)),
                Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height - _padding, -10))) * 0.5f;

            _rightCollider.localScale = new Vector3(_colDepth, _screenSize.y * 2, _colDepth);
            _rightCollider.position = new Vector3(_cameraPos.x + _screenSize.x + _rightCollider.localScale.x * 0.5f,
                _cameraPos.y, _zPosition);
            _leftCollider.localScale = new Vector3(_colDepth, _screenSize.y * 2, _colDepth);
            _leftCollider.position = new Vector3(_cameraPos.x - _screenSize.x - _leftCollider.localScale.x * 0.5f,
                _cameraPos.y, _zPosition);
            _topCollider.localScale = new Vector3(_screenSize.x * 2, _colDepth, _colDepth);
            _topCollider.position = new Vector3(_cameraPos.x,
                _cameraPos.y + _screenSize.y + _topCollider.localScale.y * 0.5f, _zPosition);
            _bottomCollider.localScale = new Vector3(_screenSize.x * 2, _colDepth, _colDepth);
            _bottomCollider.position = new Vector3(_cameraPos.x,
                _cameraPos.y - _screenSize.y - _bottomCollider.localScale.y * 0.5f, _zPosition);
        }
    }
}