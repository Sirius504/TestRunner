using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private int menuSceneIndex;

    private bool gameOver = false;

    public void GameOver()
    {
        if (gameOver)
            return;
        gameOverUI.SetActive(true);
        gameOver = true;
    }

	private void Update()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (gameOver && Input.touchCount > 0)        
#else
        if (gameOver && Input.anyKeyDown)
#endif
            SceneManager.LoadScene(menuSceneIndex);
	}
}
