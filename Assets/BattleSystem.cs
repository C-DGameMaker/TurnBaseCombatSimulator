using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public List<GameObject> battleList = new List<GameObject>();
    void Start()
    {
        battleList.Clear();

        DisplayScriptableClass[] script = FindObjectsOfType<DisplayScriptableClass>();

        foreach(DisplayScriptableClass battle in script)
        {
            battleList.Add(battle.gameObject);
        }

        foreach(GameObject battle in battleList)
        {
            Debug.Log(battle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
