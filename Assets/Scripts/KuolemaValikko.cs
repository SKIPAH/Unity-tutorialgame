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

    public void N‰yt‰(ParticleSystem h‰vi‰misefekti)
    {
        StartCoroutine(odotaEfekti‰(h‰vi‰misefekti));
    }


    IEnumerator odotaEfekti‰(ParticleSystem h‰vi‰misefekti)
    {
        while (h‰vi‰misefekti != null){
            yield return null;
        }
        if (Pisteet.instanssi.PisteidenM‰‰r‰() > PlayerPrefs.GetInt("Pisteet"))
        {
            PlayerPrefs.SetInt("Pisteet", Pisteet.instanssi.PisteidenM‰‰r‰());
        }


        pisteTeksti.text = "Pisteet: " + Pisteet.instanssi.PisteidenM‰‰r‰();
        kuolemavalikko.SetActive(true);
        Time.timeScale = 0f;
    }
}
