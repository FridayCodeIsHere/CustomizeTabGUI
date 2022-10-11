using UnityEngine;

namespace DefaultNamespace
{
    public class Content : MonoBehaviour, IContent
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}