using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour, IHealer
{
    protected bool isHealer;
    public void FullHeal(Pokemon _pokemon)
    {
        _pokemon.GotAHeal(_pokemon._pokemonObject.hp);
    }

    public void Cook(List<Pokemon> _pokemonActive)
    {
        foreach (Pokemon pokemon in _pokemonActive)
        {
            pokemon.GotAHeal(pokemon._pokemonObject.hp/2);
        }
    }
}
