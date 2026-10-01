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
    enemyTurn,
    allTurnsPassed
}


public class BattleSystem : MonoBehaviour
{
    private List<DisplayScriptableClass> speedList = new List<DisplayScriptableClass>();
    public List<GameObject> battleList;

    public List<GameObject> playerTeam;
    public List<GameObject> enemyTeam;

    public BattleStates state;
    public TurnState turnState;

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

    public void TurnStateChange(TurnState newState)
    {
        turnState = newState; 
        OnTurnStateChange(newState);
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
                ResetTurns();
                BattleStateChange(BattleStates.Inbattle);
                break;

            case BattleStates.Inbattle:
                CheckTurn();
                break;

            case BattleStates.playerTeamWin:
                Debug.Log("You won");
                break;

            case BattleStates.enemyTeamWin:
                Debug.Log("you Lost");
                break;

        }

    }

    private void OnTurnStateChange(TurnState newState)
    {
        switch (newState)
        {
            default:
                break;

            case TurnState.allTurnsPassed:
                ResetTurns();
                CheckTurn();
                CheckWin();
                break;

        }
    }

    private void ResetTurns()
    {
        DisplayScriptableClass currentTarget;

        foreach(var battle in battleList)
        {
            currentTarget = battle.GetComponent<DisplayScriptableClass>();

            if(currentTarget.characterData.hasDoneATurn == true)
            {
                currentTarget.characterData.hasDoneATurn = false;
            }
        }
    }

    private void CheckTurn()
    {
        DisplayScriptableClass currentTarget;

        foreach (GameObject battle in battleList)
        {
            currentTarget = battle.GetComponent<DisplayScriptableClass>();

            if (currentTarget.characterData.hasDoneATurn == false)
            {
                if(battle.CompareTag("Player"))
                {
                    TurnStateChange(TurnState.playerTurn);
                    break;
                }
                else if(battle.CompareTag("Enemy"))
                {
                    TurnStateChange(TurnState.enemyTurn);
                    break;
                }
            }

            else
            {
                TurnStateChange(TurnState.allTurnsPassed);
                break;
            }
        }


    }

    private void SetTeams()
    {
        foreach (GameObject battle in battleList)
        {
            if (battle.CompareTag("Player"))
            {
                playerTeam.Add(battle);
            }
            else if(battle.CompareTag("Enemy"))
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

    private void CheckWin()
    {
        if (playerTeam.Count < 0)
        {
            BattleStateChange(BattleStates.enemyTeamWin);
        }
        else if(enemyTeam.Count < 0)
        {
            BattleStateChange(BattleStates.playerTeamWin);
        }
        else
        {
            BattleStateChange(BattleStates.Inbattle);
        }
    }
}
