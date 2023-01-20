using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollistenLuoja : MonoBehaviour
{

    public Transform[] syntymiskohdat;
    public GameObject[] vihollistenPrefabit;
    float viimeksiLuodunAjankohta;

    float väliaika;
    GameObject robotti;

    void Start()
    {
        robotti = GameObject.Find("Pelihahmo");
        väliaika = 3f;
        InvokeRepeating("Nopeuta", 15f, 15);
    }
    
    void Nopeuta()
    {
        
        väliaika -= 0.1f;
        if(väliaika < 1f)
        {
            väliaika = 1f;

            CancelInvoke("Nopeuta");
        }
    }
    
    void Update()
    {
        if (robotti.activeInHierarchy && Time.time - viimeksiLuodunAjankohta > väliaika)
        {
            LuoUusiVihollinen();
        }
    }
    void LuoUusiVihollinen()
    {
        Transform kohta = syntymiskohdat[Random.Range(0, syntymiskohdat.Length)];
        GameObject vihollinen = vihollistenPrefabit[Random.Range(0, vihollistenPrefabit.Length)];
        Instantiate(vihollinen, kohta.position, kohta.rotation);
        viimeksiLuodunAjankohta = Time.time;
    }
}
