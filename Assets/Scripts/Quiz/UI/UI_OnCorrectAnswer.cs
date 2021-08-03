using UnityEngine;
using UnityEngine.UI;

namespace Quiz.Quiz
{
    public class UI_OnCorrectAnswer : MonoBehaviour
    {
        void Awake()
        {
            Button gameObjectButton = this.gameObject.transform.GetChild(1).GetComponent<Button>();
            gameObjectButton.onClick.AddListener(delegate { CorrectAnswer(); });
        }

        private void CorrectAnswer()
        {
            GameManager.Instance.NextLevel();
        }
    }
}