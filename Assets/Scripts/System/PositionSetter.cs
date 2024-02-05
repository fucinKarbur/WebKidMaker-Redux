using UnityEngine;

namespace WKMR.System
{
    public static class PositionSetter
    {
        private static float _minY = -300f;
        private static float _maxY = 350f;
        private static float _minX = -700f;
        private static float _maxX = 700f;
        private static float _z = 0;

        public static Vector3 GetRandomPosition() => new(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY), _z);

        public static Vector3 GetRandomPosition(Canvas canvas)
        {
            var transform = canvas.GetComponent<RectTransform>(); 

            float width = transform.rect.width;
            float height = transform.rect.height;

            var minX = -width / 2;
            var maxX = width / 2;
            var minY = -height / 2;
            var maxY = height / 2;

            return new(Random.Range(minX, maxX), Random.Range(minY, maxY), _z);
        }
    }
}