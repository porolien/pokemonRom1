using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trainer : Human
{
    public TrainerObject trainerObject;
    public List<Pokemon> pokemonTeam;
    public bool isMajorTrainer;
    public int numberOfPokemonKO;

    private void Start()
    {
        TrainerManager.Instance.AddATrainer(this);
        foreach (Pokemon pokemon in pokemonTeam) 
        {
            pokemon.PokemonKOEvent += PokemonIsKo;
        }
        SentenceEncounter();
        StartCoroutine(BeginFight());
    }
    public void CreateTeam(List<Pokemon> _pokemonTeam)
    {
        pokemonTeam = _pokemonTeam;
    }
    void ThrowAPokeball(Pokemon _pokemon)
    {
        Debug.Log("Go " + _pokemon.PokemonObject.pokemonName);
        foreach(Trainer allTrainer in TrainerManager.Instance.trainers) 
        {
            if(allTrainer.gameObject != this.gameObject)
            { 
                FindPokemonActive().Move += allTrainer.FindPokemonActive().ReceivedAttack;
                if(numberOfPokemonKO != 0)
                {
                    allTrainer.FindPokemonActive().Move -= pokemonTeam[numberOfPokemonKO-1].ReceivedAttack;
                    allTrainer.FindPokemonActive().Move += FindPokemonActive().ReceivedAttack;
                }
            }
        }
    }

    void SentenceEncounter()
    {
        Debug.Log(trainerObject.trainerName + " may would like to battle");
    }

    void initBattle()
    {
        ThrowAPokeball(FindPokemonActive());
        TrainerManager.Instance.trainerAreReady = true;
    }

    public void PokemonIsKo()
    {
        numberOfPokemonKO++;
        if(numberOfPokemonKO < pokemonTeam.Count) 
        {
            ThrowAPokeball(FindPokemonActive());
        }
        else
        {
            Defeat();
        }
    }

    void Defeat()
    {
        TrainerManager.Instance.trainerAreReady = false;
        TrainerManager.Instance.ChooseTheWinner(this);
    }

    public void Victory()
    {
        Debug.Log(trainerObject.trainerName + " is the winner!");
    }

    public Pokemon FindPokemonActive()
    {
        return pokemonTeam[numberOfPokemonKO];
    }

    IEnumerator BeginFight()
    {
        yield return new WaitForSeconds(0.1f);
        initBattle();
    }
}
