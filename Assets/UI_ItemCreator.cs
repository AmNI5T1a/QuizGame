using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz.Quiz
{
    public class UI_ItemCreator : MonoBehaviour
    {
        void Awake()
        {
            UI_Manager.OnSendListOfItems += InstanciateUIComponents;
        }


        private void InstanciateUIComponents(GameManager.ListOfItemsWithCorrectAnswer listOfItems)
        {
            Debug.Log("Instanciating in UI_ItemCreator all items");

            System.Random random = new System.Random();
            ushort correctAnswerPosition = (ushort)random.Next(0, listOfItems.levelItems.Count);

            foreach (Item item in listOfItems.levelItems)
            {
                GameObject instance = Instantiate(Resources.Load("Item template"), this.gameObject.transform) as GameObject;
                UI_Manager.Instance.instanciatedUI_GameObjects.Add(instance);

                instance.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = item.GetImage();
            }
        }
    }
}