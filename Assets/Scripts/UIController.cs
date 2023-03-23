using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField]
    private GameObject      mainPenel;

    [Header("InGame")]
    [SerializeField]
    private GameObject      inGamePenel;
    [SerializeField]
    private TextMeshProUGUI textScore;

    [Header("GameOver")]
    [SerializeField]
    private GameObject      gameOverPenel;
    [SerializeField]
    private TextMeshProUGUI textHighScore;

    public void GameStart()
    {
        mainPenel.SetActive(false);
        inGamePenel.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        if (score < 10)
        {
            // ToString("D2") 왼쪽에 0을 채워 적어도 두 자리 숫자가 되도록 하는 서식 지정 방법 뒤에 숫자에 따라 몇자리로 할 것인지 지정가능
            textScore.text = score.ToString("D2");
        }
        else
        {
            textScore.text = score.ToString();
        }
        
    }

    public void GameOver()
    {
        gameOverPenel.SetActive(true);

        textHighScore.text = $"HIGH SCORE : {PlayerPrefs.GetInt("HighScore")}";
    }
}
