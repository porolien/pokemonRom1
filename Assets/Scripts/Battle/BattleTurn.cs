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

    private void Update()
    {
        if (TrainerManager.Instance.trainerAreReady)
        {
            BeginTheTurn();
        }
    }

    void BeginTheTurn()
    {
        TrainerManager.Instance.seed.SeeIfTheHealerHeal();
        //Choisi qui commence en fonction de la speed des pokemons
        List<Pokemon> pokemons = _battleMain.data.FindAllPokemonActive();
        pokemons.Sort((pokemon1, pokemon2) => pokemon1.Speed.CompareTo(pokemon2.Speed));
        for (int i = pokemons.Count-1; i != -1  ; i--)
        {
            if (TrainerManager.Instance.trainerAreReady)
            {
                pokemons[i].UseAnAttack();
            }
        }
    }
}
