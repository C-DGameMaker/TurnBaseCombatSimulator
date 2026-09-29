using UnityEngine;

public class DisplayScriptableClass : MonoBehaviour
{
    public CharacterData characterData;
    void Start()
    {
        if(characterData == null)
        {
            Debug.Log("no data found");
        }
        else
        {
            Debug.Log(characterData.name);
        }
    }
}
