using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AloitusValikko : MonoBehaviour
{
    public Text ennätysPisteet;
 
    void Start()
    {
        ennätysPisteet.text = LataaPisteet().ToString();
    }

    public void Pelaa()
    {
        SceneManager.LoadScene("Maailma");
    }
    
    public void Lopeta()
    {
        Application.Quit();
    }
    public int LataaPisteet()
    {
        return PlayerPrefs.GetInt("Pisteet");
    }
   
}
