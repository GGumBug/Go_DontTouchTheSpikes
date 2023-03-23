using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField]
    private GameObject mainPenel;

    [Header("InGame")]
    [SerializeField]
    private GameObject inGamePenel;
    [SerializeField]
    private TextMeshProUGUI textScore;

    public void GameStart()
    {
        mainPenel.SetActive(false);
        inGamePenel.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        if (score < 10)
        {
            // ToString("D2") ���ʿ� 0�� ä�� ��� �� �ڸ� ���ڰ� �ǵ��� �ϴ� ���� ���� ��� �ڿ� ���ڿ� ���� ���ڸ��� �� ������ ��������
            textScore.text = score.ToString("D2");
        }
        else
        {
            textScore.text = score.ToString();
        }
        
    }
}
