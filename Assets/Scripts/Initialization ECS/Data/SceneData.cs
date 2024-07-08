using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneData : MonoBehaviour
{
    public int N;
    public int M;

    public float V;
    public Slider sliderSpeed;

    public HashSet<int> pointX = new HashSet<int>();
    public HashSet<int> pointZ = new HashSet<int>();

    public Transform ParentAnimal;
    public Transform ParentFood;

    public TextMeshProUGUI speedText;

    public void Awake()
    {
        N = PlayerPrefs.GetInt("SizeMap");
        M = PlayerPrefs.GetInt("Animal");
        V = PlayerPrefs.GetInt("Speed");

        sliderSpeed.value = V;
    }

    public void ChangeSpeed(float value)
    {
        V = (int)value;
        speedText.text = V.ToString();
    }

    public void EnterScene()
    {
        SceneManager.LoadScene(0);
    }
}
