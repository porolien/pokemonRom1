using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChooseAType;

[CreateAssetMenu(fileName = "AttackMove", menuName = "NewAssets/Create new AttackMove")]

public class AttackMoves : ScriptableObject
{
    public string moveName;
    public float attackPourcentage;
    public aType moveType;
    public bool isASpecialMove;

    public void SpecialMoveAction()
    {
        
    }
}
