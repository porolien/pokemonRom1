using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData : MonoBehaviour
{
    BattleMain _battleMain;
    List<Trainer> _trainers;
    public void Init(BattleMain _main)
    {
        _main.data = this;
        _battleMain = _main;
    }

}
