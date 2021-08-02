using System.Collections.Generic;
using UnityEngine;

namespace Quiz.Quiz
{

    [CreateAssetMenu(fileName = "New Level", menuName = "Quiz/New level")]
    public class Level : ScriptableObject
    {
        [SerializeField] public ushort ID;
        [SerializeField] protected ushort itemsOnScene;
        [SerializeField] private List<StackOfItems> listOfItemStacks;

        protected GameManager _gameManager;
        protected ILevelSwitcher _switcher;

        public void SetParams(GameManager manager, ILevelSwitcher switcher)
        {
            this._gameManager = manager;
            this._switcher = switcher;
        }

        public virtual void Stop()
        {
            // * Logic prepares scene for next level
        }

        public virtual void Start()
        {
            GenerateLevel();
        }

        public virtual void GenerateLevel()
        {
            System.Random rngGenerator = new System.Random();
            StackOfItems rndmlyChoosenStackOfItems = listOfItemStacks[rngGenerator.Next(0, listOfItemStacks.Count)];

            List<Item> list_OfChoosenItems = new List<Item>();

            for (ushort x = 0; x < itemsOnScene; x++)
            {
                Item rndlySelectedItem = rndmlyChoosenStackOfItems.stack[rngGenerator.Next(0, rndmlyChoosenStackOfItems.stack.Count)];

                if (!list_OfChoosenItems.Contains(rndlySelectedItem))
                    list_OfChoosenItems.Add(rndlySelectedItem);
                else
                    x--;
            }

            Item rndmlySelectedCorrectAnswer = list_OfChoosenItems[rngGenerator.Next(0, list_OfChoosenItems.Count)];
            list_OfChoosenItems.Remove(rndmlySelectedCorrectAnswer);

            _gameManager.SetLevelItems(listOfItems: list_OfChoosenItems,
                                        correctAnswer: rndmlySelectedCorrectAnswer);

            _gameManager.GenerateUIComponents();
        }
    }
}
