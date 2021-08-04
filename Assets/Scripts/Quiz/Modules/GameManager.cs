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
        [SerializeField] private Level _currentLevel;

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
            _currentLevel = levels[0];
            _currentLevel.GenerateLevel();
        }

        public void NextLevel()
        {
            _currentLevel.Stop();
            _currentLevel = _currentLevel.NextLevel;
            _currentLevel.Start();
        }
    }
}
