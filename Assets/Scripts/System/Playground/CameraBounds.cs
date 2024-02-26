using UnityEngine;

namespace WKMR
{
    public class CameraBounds : MonoBehaviour
    {
        [SerializeField] private float _colDepth = 2f;
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector3 _cameraPosition;
        [SerializeField] private Vector3 _bottomOffset;

        private Vector2 screenSize;
        private Transform topCollider;
        private Transform bottomCollider;
        private Transform rightCollider;
        private Transform leftCollider;

        private void Start()
        {
            // Generate our empty objects
            topCollider = new GameObject().transform;
            bottomCollider = new GameObject().transform;
            rightCollider = new GameObject().transform;
            leftCollider = new GameObject().transform;

            // Name Our Objects
            topCollider.name = "TopCollider";
            bottomCollider.name = "BottomCollider";
            rightCollider.name = "RightCollider";
            leftCollider.name = "LeftCollider";

            // Add Collider to Objects
            topCollider.gameObject.AddComponent<BoxCollider2D>();
            bottomCollider.gameObject.AddComponent<BoxCollider2D>();
            rightCollider.gameObject.AddComponent<BoxCollider2D>();
            leftCollider.gameObject.AddComponent<BoxCollider2D>();

            //Make them the child of Whatever Objects
            topCollider.parent = transform;
            bottomCollider.parent = transform;
            rightCollider.parent = transform;
            leftCollider.parent = transform;

            // Generate world space point Information
            _cameraPosition = _camera.transform.position;
            screenSize.x = Vector2.Distance(_camera.ScreenToWorldPoint(new Vector2(0f, 0f)), _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0f))) * 0.5f;
            screenSize.y = Vector2.Distance(_camera.ScreenToWorldPoint(new Vector2(0f, 0f)), _camera.ScreenToWorldPoint(new Vector2(0f, Screen.height))) * 0.5f;

            //Change our Scale and Position
            //RightCollider:
            rightCollider.localScale = new Vector3(_colDepth, screenSize.y * 2, _colDepth);
            rightCollider.position = new Vector3(_cameraPosition.x + screenSize.x + (rightCollider.localScale.x * 0.5f), _cameraPosition.y, 0f);
            //LeftCollider:
            leftCollider.localScale = new Vector3(_colDepth, screenSize.y * 2, _colDepth);
            leftCollider.position = new Vector3(_cameraPosition.x - screenSize.x - (leftCollider.localScale.x * 0.5f), _cameraPosition.y, 0f);
            //TopCollider:
            topCollider.localScale = new Vector3(screenSize.x * 2, _colDepth, _colDepth);
            topCollider.position = new Vector3(_cameraPosition.x, _cameraPosition.y + screenSize.y + (topCollider.localScale.y * 0.5f), 0f);
            //BottomCollider:
            bottomCollider.localScale = new Vector3(screenSize.x * 2, _colDepth, _colDepth);
            bottomCollider.position = new Vector3(_cameraPosition.x, _cameraPosition.y - screenSize.y - (bottomCollider.localScale.y * 0.5f), 0f) + _bottomOffset;
        }
    }
}