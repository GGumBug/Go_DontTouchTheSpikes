using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 이해가 필요한 이벤트 구조
public class RandomColor : MonoBehaviour
{
    // <Color>를 매개변수로 갖는 onChanged라는 이벤트 생성
    [SerializeField]
    private UnityEvent<Color>   onChanged;
    [SerializeField]
    private float               hueMin = 0;
    [SerializeField]
    private float               hueMax = 1;
    [SerializeField]
    private float               saturationMin = 0.7f;
    [SerializeField]
    private float               saturationMax = 1;
    [SerializeField]
    private float               valueMin = 0.7f;
    [SerializeField]
    private float               valueMax = 1;

    public void OnChange()
    {
        Color color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
        onChanged?.Invoke(color);
    }

}
