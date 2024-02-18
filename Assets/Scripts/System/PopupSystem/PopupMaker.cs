using System.Collections.Generic;
using UnityEngine;
using YG;

namespace WKMR
{
    public class PopupMaker
    {
        private readonly Dictionary<string, List<string>> _messages = new()
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
                    {"Наваждение"},
                    {"Они добыли нам Победу!"},
                    {"Жюр22"},
                    {"Пахнет радостью земля"},
                    {"ты голоден?"},
                    {"доброе утро!"},
                    {"перед сном нужно..."},
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
                    {"An obsession"},
                    {"They got us the Victory!"},
                    {"Jur22"},
                    {"The earth smells of joy"},
                    {"Are you hungry?"},
                    {"Good morning!"},
                    {"Before you go to bed you should..."},
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
                    {"Takıntı"},
                    {"Bize zafer kazandırdılar!"},
                    {"Jur22"},
                    {"Toprak neşe kokuyor"},
                    {"Aç mısın?"},
                    {"Günaydın!"},
                    {"yatmadan önce..."},
                }
            }
        };
        private readonly List<Popup> _templates;
        private readonly List<Sprite> _sprites;
        private string Language => YandexGame.savesData.language;

        public PopupMaker(List<Popup> templates, List<Sprite> sprites)
        {
            _templates = templates;
            _sprites = sprites;
        }

        public Popup GetPopup()
        {
            var popup = RandomTemplate();
            popup.Image.sprite = RandomSprite();
            popup.Text.text = RandomMessage();

            return popup;
        }

        private Popup RandomTemplate() => _templates[Random.Range(0, _templates.Count)];

        private Sprite RandomSprite() => _sprites[Random.Range(0, _sprites.Count)];

        private string RandomMessage() => _messages[Language][Random.Range(0, _messages[Language].Count)];
    }
}