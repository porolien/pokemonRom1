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
    public bool isAHealMove;
    public bool isASelfMove;
    public bool usePourcent;
    public void HealingAction(Pokemon _pokemon)
    {
        if (usePourcent)
        {
            _pokemon.GotAHeal(_pokemon._pokemonObject.hp * attackPourcentage);
        }
        else
        {
            _pokemon.GotAHeal(attackPourcentage);
        }
    }
}
