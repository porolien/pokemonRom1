using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField]
    List<Pokemon> pokemonList;
    [SerializeField]
    List<TrainerObject> trainerList;

    public void InitTheGame(int _seed)
    {
        TrainerManager.Instance.seed = this;
        Random.InitState(_seed);
        CreateATrainerWithoutPokemon();
    }

    public void GiveATeamToATrainer(Trainer _trainer)
    {
        List<TrainerObject> trainersAbleToFight = new List<TrainerObject>();
        foreach (TrainerObject trainers in trainerList) 
        { 
            if(trainers.numberOfPokemon > 0) 
            {
                trainersAbleToFight.Add(trainers);
            }
        }
        _trainer.trainerObject = trainersAbleToFight[Random.Range(0, trainersAbleToFight.Count)];
        for(int i = 0; i < _trainer.trainerObject.numberOfPokemon; i++)
        {
            Pokemon newPokemon = gameObject.AddComponent<Pokemon>();
            newPokemon._pokemonObject = pokemonList[Random.Range(0, pokemonList.Count)]._pokemonObject;
            _trainer.pokemonTeam.Add(newPokemon);
        }
    }

    void CreateATrainerWithoutPokemon()
    {
        Trainer newTrainer = new Trainer();
        List<TrainerObject> trainersNotAbleToFight = new List<TrainerObject>();
        foreach (TrainerObject trainers in trainerList)
        {            
            if (trainers.numberOfPokemon == 0)
            {
                trainersNotAbleToFight.Add(trainers);
            }
        }
        newTrainer.trainerObject = trainersNotAbleToFight[Random.Range(0, trainersNotAbleToFight.Count)];
        TrainerManager.Instance.trainerWithoutPokemon = newTrainer;
    }

    public void SeeIfTheHealerHeal()
    {
        if(Random.Range(0, 10) == 0 && TrainerManager.Instance.trainerWithoutPokemon.trainerObject.isHealer)
        {
            List<Pokemon> pokemonList = new List<Pokemon>();
            foreach(Trainer trainer in TrainerManager.Instance.trainers)
            {
                pokemonList.Add(trainer.FindPokemonActive());
            }
            if(Random.Range(0, 2) == 0)
            {
                TrainerManager.Instance.trainerWithoutPokemon.Cook(pokemonList);
                Debug.Log(TrainerManager.Instance.trainerWithoutPokemon.trainerObject.trainerName + " is cooking");
            }
            else
            {
                Pokemon pokemonToHeal = pokemonList[Random.Range(0, pokemonList.Count)];
                TrainerManager.Instance.trainerWithoutPokemon.FullHeal(pokemonToHeal);
                Debug.Log(TrainerManager.Instance.trainerWithoutPokemon.trainerObject.trainerName + " give a heal to " + pokemonToHeal);
            }
        }
    }

    public AttackMoves GiveARandomMove(List<AttackMoves> attackMoves)
    {
        return attackMoves[Random.Range(0, attackMoves.Count)];
    }
}
