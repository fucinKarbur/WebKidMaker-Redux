using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

namespace WKMR
{
    public class SavesManager : MonoBehaviour
    {
        /* [SerializeField] private ItemTemplate _template;
        [SerializeField] private ItemContainer[] _containers;

        public static List<ItemTemplate> Items = new();

        private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

        private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

        private void GetLoad()
        {
            //var datas = YandexGame.savesData.ItemsData;
            //Debug.Log("load data = " + YandexGame.savesData.ItemsData != null);

            if (YandexGame.savesData.ItemsData.Length != 0)
            {
                for (int i = 0; i < YandexGame.savesData.ItemsData.Length; i++)
                {
                    Debug.Log("try to load " + YandexGame.savesData.ItemsData[i].ScriptedName);
                    SetItem(YandexGame.savesData.ItemsData[i]);
                }
            }
            Debug.Log("load data. length = " + YandexGame.savesData.ItemsData.Length);
        }

        public void Save()
        {
            YandexGame.savesData.ItemsData = new ItemDataToSave[Items.Count];

            for (int i = 0; i < Items.Count; i++)
            {
                ItemDataToSave item = new(Items[i]);
                YandexGame.savesData.ItemsData[i] = item;
            }

            Debug.Log("save data. length = " + Items.Count);
            YandexGame.SaveProgress();
        }

        private void SetItem(ItemDataToSave data)
        {
            if (data == null)
            {
                Debug.Log("data is null ");
                return;
            }
            Debug.Log($"{data.Path} - path. {data.ScriptedName} - name");
            var Item = Resources.Load<ItemData>(data.Path + data.ScriptedName);

            if (Item == null)
            {
                Debug.Log("item not founded for " + data.Path);
                return;
            }

            var container = _containers.First(cont => cont.Type == Item.Type).transform;

            if (container == null)
            {
                Debug.Log("container not founded for " + Item.Type.ToString());
                return;
            }

            var template = Instantiate(_template, container);
            template?.Load(Item, GetColor(data.Color));
        }

        private Color GetColor(float[] colorData) => new(colorData[0], colorData[1], colorData[2], colorData[3]); */

        /* private void Load()
        {
            string key = ItemsKey + SceneManager.GetActiveScene().buildIndex;
            string countKey = ItemsCountKey + SceneManager.GetActiveScene().buildIndex;

            int count = SaveSystem.Load<int>(countKey);

            for (int i = 0; i < count; i++)
            {
                ItemsData data = SaveSystem.Load<ItemsData>(key + i);
                SetItem(data);
            }
        }

        private void SetItem(ItemsData data)
        {
            var path = $"{data._path}/{data._scriptedName}";
            var Item = Resources.Load<ItemData>(path);
            if (Item == null)
            {
                Debug.Log("item not founded for " + path);
                return;
            }
            Transform container = _containers.First(cont => cont.Type == Item.Type).transform;
            Color color = new(data._color[0], data._color[1], data._color[2], data._color[3]);

            if (container == null)
            {
                Debug.Log("container not founded for " + Item.Type.ToString());
                return;
            }

            var template = Instantiate(_template, container);
            template?.Load(Item, color);
        } 
        
        

        public void Load(ItemDataToSave data)
        {
            var scriptedItem = Resources.Load<ItemData>(data.Path);
            var container = _containers.First(cont => cont.Type == scriptedItem.Type).transform;
            var color = GetColor(data.Color);

            var respawned = new GameObject(data.ScriptedName);
            respawned.transform.SetParent(container);

            Item = data;
            SetImage(Item.Icon);
            gameObject.name = Item.name;
            transform.localPosition = Item.Offset;
            Initialize();
        }

        */
    }
}
