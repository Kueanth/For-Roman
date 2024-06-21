using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Static Data", menuName = "Data/StaticData")]
public class StaticData : ScriptableObject
{
    public GameObject Animal;
    public GameObject Food;
    public GameObject Point;
}
