using UnityEngine;
using TMPro;

namespace Quiz.Quiz
{
    public class UI_TaskUpdater : MonoBehaviour
    {
        void Awake()
        {
            UI_Manager.OnSendCorrectAnswerAsItem += SetInUICorrectAnswer;
        }

        private void SetInUICorrectAnswer(Item correctAnswer)
        {
            this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"You need to find : {correctAnswer.GetDescription()}";
        }
    }
}