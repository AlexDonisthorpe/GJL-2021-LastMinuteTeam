using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Polar.UI
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] Button nextLevelButton;
        [SerializeField] GameObject youWinCanvas;
        [SerializeField] GameObject gameOverCanvas;

        private Animator _animator;
        int currentSceneIndex;

        private void Awake()
        {
            _animator = youWinCanvas.GetComponent<Animator>();
        }

        private void Start()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
        
        public void LoadNextLevel()
        {
            Time.timeScale = 1;
            var nextLevelIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextLevelIndex);
        }

        public void ReloadLevel()
        {
            Time.timeScale = 1;
            FindObjectOfType<HealthUI>().UpdateLives(3);
            SceneManager.LoadScene(currentSceneIndex);
        }

        public void ReturnToMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void LoadYouWinCanvas()
        {
            youWinCanvas.SetActive(true);
        }

        public void LoadGameOverCanvas()
        {
            gameOverCanvas.SetActive(true);
        }

        public bool DoesNextLevelExist()
        {
            int totalScenes = SceneManager.sceneCountInBuildSettings;

            if (currentSceneIndex == totalScenes - 1)
            {
                return false;
            } else
            {
                return true;
            }
        }

    }
}
