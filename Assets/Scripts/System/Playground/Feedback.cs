using UnityEngine;
using YG;

namespace WKMR
{
    public class Feedback : MonoBehaviour
    {
        [SerializeField] private GameObject[] _itchFeedback;
        [SerializeField] private GameObject[] _yaFeedback;

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                SwitchForms(_yaFeedback, _itchFeedback);
            else
                SwitchForms(_itchFeedback, _yaFeedback);
        }

        private void SwitchForms(GameObject[] active, GameObject[] toDestroy)
        {
            foreach (var obj in toDestroy)
                Destroy(obj);

            foreach (var obj in active)
                obj.SetActive(true);
        }
    }
}
