using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    BattleMain _battleMain;
    
    public void Init(BattleMain _main)
    {
        _main.UI = this;
        _battleMain = _main;
    }

    void ShowAttack()
    {

    }
}
