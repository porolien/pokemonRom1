using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData : MonoBehaviour
{
    BattleMain _battleMain;
    public void Init(BattleMain _main)
    {
        _main.data = this;
        _battleMain = _main;
    }

    public List<Pokemon> FindAllPokemonActive()
    {
        List<Pokemon> pokemonActive = new List<Pokemon>();
        for(int i=0; i < TrainerManager.Instance.trainers.Count; i++) 
        {
            pokemonActive.Add(TrainerManager.Instance.trainers[i].FindPokemonActive());
        }
        return pokemonActive;
    }
}