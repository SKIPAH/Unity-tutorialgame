using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmonKuoleminen : Kuoleminen
{
    ParticleSystem h‰vi‰misefekti;
    AudioSource kuolema‰‰ni;

     void Start()
    {
        h‰vi‰misefekti = GetComponentInChildren<ParticleSystem>();
        kuolema‰‰ni = GetComponentsInChildren<AudioSource>()[1];
    }

    void Update()
    {
        kuolema‰‰ni.GetComponent<AudioSource>().volume = 20f;
        El‰m‰pisteet += Time.deltaTime;
        El‰m‰pisteetPalkki.instanssi.P‰ivit‰(El‰m‰pisteet);
    }

    protected override void Kuole()
    {
        h‰vi‰misefekti.transform.SetParent(null);
        h‰vi‰misefekti.Play();
        kuolema‰‰ni.Play();
        gameObject.SetActive(false);
        KuolemaValikko.instanssi.N‰yt‰(h‰vi‰misefekti);
    }
}
