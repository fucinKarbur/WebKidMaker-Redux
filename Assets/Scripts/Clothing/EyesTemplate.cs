using UnityEngine;

namespace WKMR
{
    public class EyesTemplate: ClothTemplate
    {
        private EyesData _eyesData;

        public void GetData(EyesData data) => _eyesData = data;

        public override void SetColor(Color color)
        {
            Image.sprite = _eyesData.ChangeType(color);
        }
    }
}