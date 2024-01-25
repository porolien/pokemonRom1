using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealer 
{
    void FullHeal(Pokemon _pokemon);
    void Cook(List<Pokemon> _pokemonActive);
}
