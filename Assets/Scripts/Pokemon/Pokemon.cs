using System;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public PokemonObject _pokemonObject;
    public PokemonObject PokemonObject
    {
        get { return _pokemonObject; }
    }

    public event Action <AttackMoves, float> Move;
    public event Action PokemonKOEvent;

    AttackMoves _moveToUseThisTurn;
    
    float hp;
    float attack;
    float armor;
    float speed;
    public float Speed
    {
        get { return speed ;}
    }
    void Start()
    {
        Constructor();
       // Move += UseAnAttack;
    }

    void Constructor()
    {
        hp = _pokemonObject.hp; 
        armor = _pokemonObject.armor;
        attack = _pokemonObject.attack;
        speed = _pokemonObject.speed;
    }

    public void UseAnAttack()
    {
        ChooseAMove();
        Debug.Log(PokemonObject.pokemonName + " use " + _moveToUseThisTurn.moveName);
        if (!_moveToUseThisTurn.isASelfMove)
        {
            Move(_moveToUseThisTurn, attack);
        }
        else
        {
            UseASelfMove();
        }
    }

    void ChooseAMove()
    {
        _moveToUseThisTurn = TrainerManager.Instance.seed.GiveARandomMove(_pokemonObject.moves);
    }

    public void ReceivedAttack(AttackMoves _moveReceived, float _pokemonPower)
    {
        TakeDamage(CalculateDamage(_moveReceived, _pokemonPower));
        TakeEffectFromAttack(_moveReceived);
    }

    void TakeDamage(float _damage)
    {
        hp -= _damage;
        Debug.Log(_pokemonObject.pokemonName + " lose " + _damage + " hp");
        if(hp <= 0)
        {
            Dead();
        }
        else
        {
            Debug.Log(_pokemonObject.pokemonName + " has " + hp + " Hp");
        }
    }

    void UseASelfMove()
    {
        if(_moveToUseThisTurn.isAHealMove) 
        {
            _moveToUseThisTurn.HealingAction(this);
        }
    }

    float CalculateDamage(AttackMoves _moveReceived, float _pokemonPower)
    {
        float damageDeal = (_pokemonPower * _moveReceived.attackPourcentage - (armor / 2)) *ChooseAType.StrongType(_moveReceived.moveType, _pokemonObject.pokemonType);
        if (damageDeal < 10)
        {
            damageDeal = 10;
        }
        return damageDeal;
    }

    void TakeEffectFromAttack(AttackMoves _effectReceived)
    {

    }

    public void GotAHeal(float _heal)
    {
        Debug.Log(_pokemonObject.pokemonName + " gain " + _heal + " hp");
        if (hp + _heal >= _pokemonObject.hp) 
        {
            hp = _pokemonObject.hp;
        }
        else
        {
            hp += _heal;
        }
        Debug.Log(_pokemonObject.pokemonName + " has " + hp + " Hp");
    }

    void Dead()
    {
        Debug.Log(_pokemonObject.pokemonName + " is KO");
        PokemonKOEvent();
    }
}
