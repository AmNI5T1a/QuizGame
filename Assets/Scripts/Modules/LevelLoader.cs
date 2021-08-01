using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quiz.Modules
{
    public class LevelLoader : Singleton<LevelLoader>
    {
        private static bool sceneIsLoading;
        private AsyncOperation operation;



        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private IEnumerator Load(int sceneIdToLoad)
        {
            sceneIsLoading = true;

            operation = SceneManager.LoadSceneAsync(sceneBuildIndex: sceneIdToLoad);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                Debug.Log("Current loading progress: " + (operation.progress * 100) + "%");
                Scene loadedScene = SceneManager.GetSceneByBuildIndex(sceneIdToLoad);

                if (operation.progress >= 0.9f)
                {
                    Debug.LogWarning("Scene is loaded!");
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        operation.allowSceneActivation = true;
                    }
                }
                yield return null;
            }

            sceneIsLoading = false;
            Destroy(this.gameObject);
        }

        public void LoadScene(int sceneIdToLoad)
        {
            if (!sceneIsLoading)
                StartCoroutine(Load(sceneIdToLoad));
            else
                Debug.LogWarning("Scene is already loading!");
        }
    }
}