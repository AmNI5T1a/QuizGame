using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz.Quiz
{
    public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager Instance;

        public List<GameObject> instanciatedUI_GameObjects;
        private Item correctAnswer;
        public static event Action<List<Item>> OnSendListOfItems;
        public static event Action<Item> OnSendCorrectAnswerAsItem;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void SetCorrectAnswer(Item item)
        {
            correctAnswer = item;
            OnSendCorrectAnswerAsItem?.Invoke(correctAnswer);
        }

        public void InstanciateUIComponents(List<Item> items)
        {
            OnSendListOfItems?.Invoke(items);
        }
    }
}
