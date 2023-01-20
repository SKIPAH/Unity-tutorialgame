using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pisteet : MonoBehaviour
{

    public static Pisteet instanssi;
    public Text teksti;
    int pisteet;



    void Start()
    {
        instanssi = this;
    }

    public void Lis‰‰(int m‰‰r‰)
    {
        pisteet += m‰‰r‰;
        teksti.text = pisteet.ToString();
    }

    public int PisteidenM‰‰r‰()
    {
        return pisteet;
    }
}
   
