using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VihollisenLiikkuminen : MonoBehaviour
{

    NavMeshAgent agentti;
    Transform robotti;
    Vector3 määränpää;
    HahmonKuoleminen hahmonKuoleminen;
    public float hyökkäysLujuus = 15f;
    public float hyökkäysNopeus = 2f;
    float viimeHyökkäys;

    AudioSource hyökkäysääni;
    public AudioClip hyökkäysääni1;
    
    void Start()
    {
        agentti = GetComponent<NavMeshAgent>();
        määränpää = agentti.destination;
        robotti = GameObject.Find("Pelihahmo").transform;
        hahmonKuoleminen = robotti.GetComponent<HahmonKuoleminen>();
        hyökkäysääni = GetComponentInChildren<AudioSource>();
        hyökkäysääni.GetComponent<AudioSource>().volume = 0.1f;
    }

    
    void Update()
    {
        if (!robotti.gameObject.activeInHierarchy)
            return;
        if(Time.time - viimeHyökkäys >= hyökkäysNopeus)
        {
            if(agentti.hasPath && agentti.remainingDistance <= agentti.stoppingDistance)
            {
                hyökkäysääni.clip = hyökkäysääni1;
                hyökkäysääni.Play();
                hahmonKuoleminen.Elämäpisteet -= hyökkäysLujuus;
                ElämäpisteetPalkki.instanssi.Päivitä(hahmonKuoleminen.Elämäpisteet);
                viimeHyökkäys = Time.time;
            }
        }

        if(Vector3.Distance(robotti.position, määränpää)> 1.0f)
        {
            määränpää = robotti.position;
            agentti.destination = määränpää;
        }
    }
}
