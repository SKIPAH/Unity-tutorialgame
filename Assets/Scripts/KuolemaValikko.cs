using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KuolemaValikko : MonoBehaviour
{
    public static KuolemaValikko instanssi;
    public GameObject kuolemavalikko;
    public Text pisteTeksti;
    void Start()
    {
        instanssi = this;
    }

    public void Näytä(ParticleSystem häviämisefekti)
    {
        StartCoroutine(odotaEfektiä(häviämisefekti));
    }


    IEnumerator odotaEfektiä(ParticleSystem häviämisefekti)
    {
        while (häviämisefekti != null){
            yield return null;
        }
        if (Pisteet.instanssi.PisteidenMäärä() > PlayerPrefs.GetInt("Pisteet"))
        {
            PlayerPrefs.SetInt("Pisteet", Pisteet.instanssi.PisteidenMäärä());
        }


        pisteTeksti.text = "Pisteet: " + Pisteet.instanssi.PisteidenMäärä();
        kuolemavalikko.SetActive(true);
        Time.timeScale = 0f;
    }
}
