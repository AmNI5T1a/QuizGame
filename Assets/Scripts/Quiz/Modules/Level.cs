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

            // ! If u added only 1 stack it will choose this stack exactly
            StackOfItems rndmlyChoosenStackOfItems = listOfItemStacks[rngGenerator.Next(0, listOfItemStacks.Count - 1)];

            List<Item> list_OfChoosenItems = new List<Item>();

            while (list_OfChoosenItems.Count != 3)
            {
                Item rndmlySelectedItem = rndmlyChoosenStackOfItems.stack[rngGenerator.Next(0, rndmlyChoosenStackOfItems.stack.Count - 1)];

                if (!list_OfChoosenItems.Contains(rndmlySelectedItem))
                    list_OfChoosenItems.Add(rndmlySelectedItem);
            }

            _gameManager.SetCurrentLevelItems(items: list_OfChoosenItems);
            _gameManager.GenerateItemsAsUIComponents();
        }
    }
}
