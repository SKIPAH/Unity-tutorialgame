using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Kuoleminen : MonoBehaviour
{
    [SerializeField]
    private float elämäpisteet = 100f;
    public float vaurioKerroin = 1f;

    public float Elämäpisteet
    {
        get
        {
            return elämäpisteet;
        }
        set
        {
            float uusiArvo = value;
            if(uusiArvo < elämäpisteet)
            {
                float muutos = uusiArvo - elämäpisteet;
                uusiArvo = elämäpisteet + muutos * vaurioKerroin;
            }
            elämäpisteet = Mathf.Clamp(uusiArvo, 0f, 100f);
            if(elämäpisteet == 0f)
            {
                Kuole();
            }
        }
    }

    protected abstract void Kuole();

}
