using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Aika : MonoBehaviour
{
    public Text teksti;
    int viimeAika;
    // Update is called once per frame
    void Update()
    {
        int nykyinenAika = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        if(nykyinenAika != viimeAika)
        {
            teksti.text = muunnaTekstiksi(nykyinenAika);
            viimeAika = nykyinenAika;
        }
    }

    private string muunnaTekstiksi(int aika)
    {
        int tunnit = aika / 3600;
        int minuutit = (aika % 3600) / 60;
        int sekunnit = aika % 60;
        if(tunnit > 0)
             return string.Format("{0:D2}:{1:D2}:{2:D2}", tunnit, minuutit, sekunnit);
            return string.Format("{0:D2}:{1:D2}", minuutit, sekunnit);
        
    }
}
