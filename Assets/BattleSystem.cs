using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private List<DisplayScriptableClass> speedList = new List<DisplayScriptableClass>();
    public List<GameObject> battleList;
    void Start()
    {
        speedList.Clear();
        battleList.Clear();

        DisplayScriptableClass[] script = FindObjectsOfType<DisplayScriptableClass>();

        foreach(DisplayScriptableClass battle in script)
        {
            speedList.Add(battle);
        }

        speedList = speedList.OrderByDescending(speed => speed.characterData._speed).ToList();

        foreach(DisplayScriptableClass speed in speedList)
        {
            Debug.Log(speed.characterData._name + ": " + speed.characterData._speed);
        }

        foreach (DisplayScriptableClass battle in speedList)
        {
            battleList.Add(battle.gameObject);
        }

        foreach (GameObject battle in battleList)
        {
            Debug.Log(battle);
        }

    }
}
