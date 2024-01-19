using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTurn : MonoBehaviour
{
    BattleMain _battleMain;
    public void Init(BattleMain _main)
    {
        _main.turn = this;
        _battleMain = _main;
    }
}
