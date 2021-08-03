using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz.Quiz
{
    public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager Instance;

        public List<GameObject> instanciatedUI_GameObjects;
        public static event Action<List<Item>> OnSendListOfItems;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }


        public void InstanciateUIComponents(List<Item> items)
        {
            OnSendListOfItems?.Invoke(items);
        }
    }
}
