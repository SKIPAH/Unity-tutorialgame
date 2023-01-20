using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ElämäpisteetPalkki : MonoBehaviour

{

    public static ElämäpisteetPalkki instanssi;

    public Image kuva;

    // Start is called before the first frame update
    void Start()
    {
        instanssi = this;
    }

    public void Päivitä(float elämäpisteet) {
        kuva.fillAmount = elämäpisteet / 100f;
    }

}


 
