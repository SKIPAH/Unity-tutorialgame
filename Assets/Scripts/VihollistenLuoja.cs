using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollistenLuoja : MonoBehaviour
{

    public Transform[] syntymiskohdat;
    public GameObject[] vihollistenPrefabit;
    float viimeksiLuodunAjankohta;

    float v�liaika;
    GameObject robotti;

    void Start()
    {
        robotti = GameObject.Find("Pelihahmo");
        v�liaika = 3f;
        InvokeRepeating("Nopeuta", 15f, 15);
    }
    
    void Nopeuta()
    {
        
        v�liaika -= 0.1f;
        if(v�liaika < 1f)
        {
            v�liaika = 1f;

            CancelInvoke("Nopeuta");
        }
    }
    
    void Update()
    {
        if (robotti.activeInHierarchy && Time.time - viimeksiLuodunAjankohta > v�liaika)
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
