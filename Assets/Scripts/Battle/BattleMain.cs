using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMain : MonoBehaviour
{
    public BattleTurn turn;
    public BattleData data;
    private void Start()
    {
        gameObject.SendMessage("Init", this);
    }
}
