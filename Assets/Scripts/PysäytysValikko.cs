using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PysäytysValikko : MonoBehaviour
{
    public GameObject pysäytysvalikko;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool avaa = !pysäytysvalikko.activeInHierarchy;
            pysäytysvalikko.SetActive(avaa);
            Time.timeScale = avaa ? 0 : 1;
        }
    }

    public void Jatka()
    {
        pysäytysvalikko.SetActive(false);
        Time.timeScale = 1;
    }

    public void AloitaAlusta()
    {
        if (Pisteet.instanssi.PisteidenMäärä() > PlayerPrefs.GetInt("Pisteet"))
        {
            PlayerPrefs.SetInt("Pisteet", Pisteet.instanssi.PisteidenMäärä());
        }
        SceneManager.LoadScene("Maailma");
        Time.timeScale = 1;
    }

    public void Aloitusvalikko()
    {
        if (Pisteet.instanssi.PisteidenMäärä() > PlayerPrefs.GetInt("Pisteet"))
        {
            PlayerPrefs.SetInt("Pisteet", Pisteet.instanssi.PisteidenMäärä());
        }
        SceneManager.LoadScene("Aloitusvalikko");
        Time.timeScale = 1;
    }
    
}
