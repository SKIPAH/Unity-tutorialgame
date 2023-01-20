using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihollisenKuoleminen : Kuoleminen
{
    ParticleSystem h‰vi‰misefekti;
    public int pisteAnsio;
    AudioSource kuolema‰‰nivihu;

    void Start()
    {
        h‰vi‰misefekti = GetComponentInChildren<ParticleSystem>();
        kuolema‰‰nivihu = GetComponentInChildren<AudioSource>();
    }
    

  
    protected override void Kuole()
    {
        h‰vi‰misefekti.transform.SetParent(null);
        h‰vi‰misefekti.Play();
        kuolema‰‰nivihu.Play();
        Pisteet.instanssi.Lis‰‰(pisteAnsio);
        Destroy(gameObject);
        
    }
}
