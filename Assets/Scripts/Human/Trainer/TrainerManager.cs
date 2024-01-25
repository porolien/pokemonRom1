using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerManager : MonoBehaviour
{
    private static TrainerManager _instance = null;

    public static TrainerManager Instance => _instance;

    public List<Trainer> trainers = new List<Trainer>();

    public Trainer trainerWithoutPokemon;

    public bool trainerAreReady;

    public Seed seed;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChooseTheWinner(Trainer _loser)
    {
        Debug.Log("Victor");
        foreach (var trainer in trainers) 
        { 
            if(trainer.gameObject != _loser.gameObject) 
            { 
                trainer.Victory();
            }
        }
    }

    public void AddATrainer(Trainer _trainer)
    {
        seed.GiveATeamToATrainer(_trainer);
        trainers.Add(_trainer);
    }
}
