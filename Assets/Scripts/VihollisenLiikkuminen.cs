using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VihollisenLiikkuminen : MonoBehaviour
{

    NavMeshAgent agentti;
    Transform robotti;
    Vector3 m��r�np��;
    HahmonKuoleminen hahmonKuoleminen;
    public float hy�kk�ysLujuus = 15f;
    public float hy�kk�ysNopeus = 2f;
    float viimeHy�kk�ys;

    AudioSource hy�kk�ys��ni;
    public AudioClip hy�kk�ys��ni1;
    
    void Start()
    {
        agentti = GetComponent<NavMeshAgent>();
        m��r�np�� = agentti.destination;
        robotti = GameObject.Find("Pelihahmo").transform;
        hahmonKuoleminen = robotti.GetComponent<HahmonKuoleminen>();
        hy�kk�ys��ni = GetComponentInChildren<AudioSource>();
        hy�kk�ys��ni.GetComponent<AudioSource>().volume = 0.1f;
    }

    
    void Update()
    {
        if (!robotti.gameObject.activeInHierarchy)
            return;
        if(Time.time - viimeHy�kk�ys >= hy�kk�ysNopeus)
        {
            if(agentti.hasPath && agentti.remainingDistance <= agentti.stoppingDistance)
            {
                hy�kk�ys��ni.clip = hy�kk�ys��ni1;
                hy�kk�ys��ni.Play();
                hahmonKuoleminen.El�m�pisteet -= hy�kk�ysLujuus;
                El�m�pisteetPalkki.instanssi.P�ivit�(hahmonKuoleminen.El�m�pisteet);
                viimeHy�kk�ys = Time.time;
            }
        }

        if(Vector3.Distance(robotti.position, m��r�np��)> 1.0f)
        {
            m��r�np�� = robotti.position;
            agentti.destination = m��r�np��;
        }
    }
}
