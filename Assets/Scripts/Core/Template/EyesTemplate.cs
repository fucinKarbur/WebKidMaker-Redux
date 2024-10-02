using UnityEngine;

namespace WKMR.Clothing
{
    public class EyesTemplate : ItemTemplate
    {
        private EyesData _eyesData;

        public override void SetColor(Color color)
        {
            if (_eyesData == null)
                Debug.LogError("EyesData is null");
            else
                Image.sprite = _eyesData.ChangeSprite(color);
        }

        public override void Initialize(ItemData data)
        {
            base.Initialize(data);
            _eyesData = data as EyesData;
        }
    }
}