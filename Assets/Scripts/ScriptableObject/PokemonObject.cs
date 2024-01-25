using System.Collections.Generic;
using UnityEngine;
using static ChooseAType;

[CreateAssetMenu(fileName = "Pokemon", menuName = "NewAssets/Create new Pokemon")]
public class PokemonObject : ScriptableObject
{
    public string pokemonName;
    public int hp;
    public int attack;
    public int armor;
    public int speed;
    public aType pokemonType;
    public List<AttackMoves> moves;
}
