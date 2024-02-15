using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace WKMR.System
{
    public class PopupSpawner : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Toggle _switcher;
        [SerializeField] private List<Popup> _templates;
        [SerializeField] private List<Sprite> _sprites;

        private float _delay = 5;
        private WaitForSeconds _wait;
        private string _language;
        private bool _working = true;

        private Dictionary<string, List<string>> _messages = new()
        {
            {
                "ru", new List<string>()
                {
                    { "Вкусные фрукты!!"},
                    { "ты не поверишь...."},
                    { "Люблю купаться!"},
                    { "Как поживаешь?"},
                    { "Это интересно!"},
                    { "Скидки! Акцияю..."},
                }
            },
            {
                "en", new List<string>()
                {
                    { "Delicious fruits!!"},
                    { "You won't believe...."},
                    { "I love swimming!"},
                    { "How are you doing?"},
                    { "That's interesting!"},
                    { "Discounts! Promotion..."},
                }
            },
            {
                "tr", new List<string>()
                {
                    { "Lezzetli meyveler!!"},
                    { "İnanmayacaksın...."},
                    { "Yüzmeyi seviyorum!"},
                    { "Nasılsın?"},
                    { "Bu ilginç!"},
                    { "İndirimler! Kampanya..."},
                }
            }
        };

        private void Awake()
        {
            _wait = new(_delay);
            _language = YandexGame.EnvironmentData.language;
            SwitchMode();
        }

        public void SwitchMode()
        {
            if (_switcher.isOn)
            {
                _working = true;
                StartCoroutine(SpawnPopups());
            }
            else if (_switcher.isOn == false)
            {
                _working = false;
                StopSpawning();
            }
        }

        private IEnumerator SpawnPopups()
        {
            while (_working)
            {
                yield return _wait;
                var popup = Instantiate(RandomTemplate(), transform);
                SetPopup(popup);
            }
        }

        private void StopSpawning()
        {
            StopAllCoroutines();

            foreach (var popup in transform.GetComponentsInChildren<Popup>())
                popup?.Close();
        }

        private void SetPopup(Popup spawned)
        {
            spawned.Transform.anchoredPosition = PositionRandomiser.GetRandomPosition(_canvas);
            spawned.Image.sprite = RandomSprite();
            spawned.Text.text = RandomMessage();
        }

        private string RandomMessage() => _messages[_language][Random.Range(0, _messages[_language].Count)];

        private Sprite RandomSprite() => _sprites[Random.Range(0, _sprites.Count)];

        private Popup RandomTemplate() => _templates[Random.Range(0, _templates.Count)];
    }
}