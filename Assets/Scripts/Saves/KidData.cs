using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WKMR
{
    public class KidData : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _health;
        [SerializeField] private KidDeleter _deleter;

        private readonly KidConverter _converter = new();

        public int Index { get; private set; }
        public KidDeleter Deleter => _deleter;

        public void SetData(byte[] bytedTexture, string name, int health, int index)
        {
            _image.texture = _converter.ConvertBytesToTexture(bytedTexture);
            _name.text = name;
            _health.text = health.ToString() + "%";
            Index = index;
        }
    }
}