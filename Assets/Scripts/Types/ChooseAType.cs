using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class ChooseAType 
{
    public enum aType { Fire, Water, Grass, Normal };

    public static float StrongType(aType attack, aType defenseur)
    {
        float MultiplierDamage = 1;
        switch (attack) 
        { 
            case aType.Fire:
                if(defenseur == aType.Water || defenseur == aType.Fire)
                {
                    MultiplierDamage = 0.5f;
                }
                else if (defenseur == aType.Grass)
                {
                        MultiplierDamage = 2;
                }
                break;
            case aType.Water:
                if (defenseur == aType.Water || defenseur == aType.Grass)
                {
                    MultiplierDamage = 0.5f;
                }
                else if (defenseur == aType.Fire)
                {
                    MultiplierDamage = 2;
                }
                break;
            case aType.Grass:
                if (defenseur == aType.Fire || defenseur == aType.Grass)
                {
                    MultiplierDamage = 0.5f;
                }
                else if (defenseur == aType.Water)
                {
                    MultiplierDamage = 2;
                }
                break;
        }
        return MultiplierDamage;
    }
}
