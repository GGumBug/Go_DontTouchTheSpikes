using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SpikeSpawner[] spikeSpawners;
    [SerializeField]
    private Player player;
    private UIController uiController;
    private RandomColor randomColor;
    private int currentSpawn = 0;
    private int currentScore = 0;

    private void Awake()
    {
        uiController = GetComponent<UIController>();
        randomColor = GetComponent<RandomColor>();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.GameStart();
                uiController.GameStart();

                yield break;
            }

            yield return null;
        }
    }

    public void CollisionWithWall()
    {
        UpdateSpikes();

        currentScore++;
        uiController.UpdateScore(currentScore);

        randomColor.OnChange();
    }

    public void GameOver()
    {
        StartCoroutine(nameof(GameOverProcess));
    }

    private void UpdateSpikes()
    {
        spikeSpawners[currentSpawn].ActivateAll();

        // 상태를 반대로 스위치할때 나머지를 많이 쓴다.
        currentSpawn = (currentSpawn+1) % spikeSpawners.Length;

        spikeSpawners[currentSpawn].DeactivateAll();
    }

    private IEnumerator GameOverProcess()
    {
        if (currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }

        uiController.GameOver();

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }

            yield return null;
        }
    }
}
