using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public Slider sliderAnimal;
    public Slider sliderSpeed;
    public Slider sliderSizeMap;

    public TextMeshProUGUI textAnimal;
    public TextMeshProUGUI textSizeMap;
    public TextMeshProUGUI textSpeed;

    public void Awake()
    {
        sliderSpeed.value = PlayerPrefs.GetInt("Speed");
        sliderSizeMap.value = PlayerPrefs.GetInt("SizeMap");
        sliderAnimal.value = PlayerPrefs.GetInt("Animal");

        textAnimal.text = sliderAnimal.value.ToString();
        textSizeMap.text = sliderSizeMap.value.ToString();
        textSpeed.text = sliderSpeed.value.ToString();
    }

    public void SizeMap(float value)
    {
        PlayerPrefs.SetInt("SizeMap", (int)value);
        sliderAnimal.maxValue = (int) ((value * value) / 2) ;
        textSizeMap.text = sliderSizeMap.value.ToString();
    }

    public void Animal(float value)
    {
        PlayerPrefs.SetInt("Animal", (int)value);
        textAnimal.text = sliderAnimal.value.ToString();
    }

    public void Speed(float value)
    {
        PlayerPrefs.SetInt("Speed", (int)value);
        textSpeed.text = sliderSpeed.value.ToString();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
