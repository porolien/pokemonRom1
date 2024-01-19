using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : Human
{
    TrainerObject trainerObject;
    public List<PokemonObject> pokemonTeam;

    void CreateTeam()
    {
        //Init Pokemon of trainer
    }
    void ThrowAPokeball()
    {
        Debug.Log("Go " + pokemonTeam[0].pokemonName);
    }

    void initBattle()
    {
        Debug.Log(trainerObject.trainerName + " may would like to battle");
    }
}
