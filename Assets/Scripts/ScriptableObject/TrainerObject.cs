using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trainer", menuName = "NewAssets/Create new Trainer")]
public class TrainerObject : ScriptableObject
{
    public int numberOfPokemon;
    public string trainerName;
    public bool isHealer;
    //Rajouter un event
}
