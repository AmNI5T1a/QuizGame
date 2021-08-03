using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Quiz.Modules;

namespace Quiz.Quiz
{
    public class UI_ItemCreator : MonoBehaviour
    {
        void Awake()
        {
            UI_Manager.OnSendListOfItems += InstanciateUIComponents;
        }


        private void InstanciateUIComponents(List<Item> listOfItems)
        {
            System.Random rng = new System.Random();
            int rngCorrectAnswerPosition = rng.Next(0, (listOfItems.Count));

            int x = 0;
            foreach (Item item in listOfItems)
            {
                GameObject gameObject = CreateItem(item);

                if (x == rngCorrectAnswerPosition)
                {
                    gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(102, 20, 100, 255);
                }
                UI_Manager.Instance.instanciatedUI_GameObjects.Add(gameObject);
                x++;
            }
        }

        private GameObject CreateItem(Item item)
        {
            GameObject itemGameObjectInstance = Instantiate(Resources.Load("Item template"), this.gameObject.transform) as GameObject;
            itemGameObjectInstance.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = item.GetImage();

            return itemGameObjectInstance;
        }
    }
}