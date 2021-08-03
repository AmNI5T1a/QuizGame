using UnityEngine;
using Quiz.Modules;

namespace Quiz.MainMenu
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void StartGame(int sceneID)
        {
            Debug.Log(@$"Loading scene with {sceneID} ID");
            LevelLoader.Instance.LoadScene(sceneID);
        }

        public void QuitGame()
        {
            Debug.Log("Quiting application");
            Application.Quit();
        }
    }
}
