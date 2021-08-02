using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz.Quiz
{
    public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager Instance;

        public List<GameObject> instanciatedUI_GameObjects;
        public static event Action<GameManager.ListOfItemsWithCorrectAnswer> OnSendListOfItems;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }


        public void InstanciateUIComponents(GameManager.ListOfItemsWithCorrectAnswer items)
        {
            OnSendListOfItems?.Invoke(items);
        }
    }
}
