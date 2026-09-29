using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum BattleStates
{ 
    init,
    Inbattle,
    playerTeamWin,
    enemyTeamWin,

}

public enum TurnState
{ 
    playerTurn,
    enemyTurn
}


public class BattleSystem : MonoBehaviour
{
    private List<DisplayScriptableClass> speedList = new List<DisplayScriptableClass>();
    public List<GameObject> battleList;

    public List<GameObject> playerTeam;
    public List<GameObject> enemyTeam;

    public BattleStates state;
    TurnState turnState;

    void Start()
    {
        speedList.Clear();
        battleList.Clear();
        playerTeam.Clear();
        enemyTeam.Clear();
        BattleStateChange(BattleStates.init);
    }

    public void BattleStateChange(BattleStates newState)
    {
        state = newState; 
        OnBattleStateChange(newState);
    }


    private void OnBattleStateChange(BattleStates newState)
    {
        switch (newState)
        {
            default:
                break;

            case BattleStates.init:
                SetBattle();
                SetTeams();
                BattleStateChange(BattleStates.Inbattle);
                break;
        
        }

    }

    private void SetTurn()
    {
        
    }

    private void SetTeams()
    {
        foreach (GameObject battle in battleList)
        {
            if (battle.CompareTag("Player"))
            {
                playerTeam.Add(battle);
            }
            else
            {
                enemyTeam.Add(battle);
            }
        }
    }

    private void SetBattle()
    {
        DisplayScriptableClass[] script = FindObjectsOfType<DisplayScriptableClass>();

        foreach (DisplayScriptableClass battle in script)
        {
            speedList.Add(battle);
        }

        speedList = speedList.OrderByDescending(speed => speed.characterData._speed).ToList();



        foreach (DisplayScriptableClass battle in speedList)
        {
            battleList.Add(battle.gameObject);
        }
    }
}
