using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quiz.Quiz
{
    public class GameManager : MonoBehaviour, ILevelSwitcher
    {
        public static GameManager Instance;

        [Header("References: ")]
        [SerializeField] private GameObject UI;

        [Header("Stats: ")]
        [SerializeField] private List<Level> levels;

        [Header("Info box:")]
        private ListOfItemsWithCorrectAnswer items = new ListOfItemsWithCorrectAnswer();

        public class ListOfItemsWithCorrectAnswer
        {
            public List<Item> levelItems;
            public Item choosenCorrectAnswer;
        }

        private Level _currentLevel;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Start()
        {
            foreach (Level level in levels)
            {
                level.SetParams(this, this.gameObject.GetComponent<ILevelSwitcher>());
            }
        }

        public void GenerateUIComponents()
        {
            UI_Manager.Instance.InstanciateUIComponents(items);
        }

        public void SetLevelItems(List<Item> listOfItems, Item correctAnswer)
        {
            items.levelItems = listOfItems;
            items.choosenCorrectAnswer = correctAnswer;
        }

        public void NextLevel(Level nextLevel)
        {
            _currentLevel.Stop();
            _currentLevel = nextLevel;
            _currentLevel.Start();
        }
    }
}
