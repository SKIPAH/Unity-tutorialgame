using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmonAmpuminen : MonoBehaviour
{


    public LineRenderer[] tykit;
    public float ampumisLujuus = 50f;
    public float ampumisEtäisyys = 12f;
    public float ampumisNopeus = 0.25f;
    public float laserSäteenNopeus = 40f;
    float viimeAmpuminen;
    int ampumistenLukumäärä;

    AudioSource ampumisääni;

    void Start()
    {
        ampumisääni = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if(Input.GetMouseButton(0) && Time.time - viimeAmpuminen >= ampumisNopeus)
        {
            
            Ammu();
        }
        SäteidenLento();

        void Ammu()
        {
            ampumisääni.Play();
            LineRenderer tykki = tykit[++ampumistenLukumäärä % 2];
            Ray säde = new Ray(tykki.transform.position, tykki.transform.forward);
            RaycastHit osuma;
            Vector3 päätePiste;
            if(Physics.Raycast(säde, out osuma, ampumisEtäisyys))
            {
                päätePiste = osuma.point;
                if (osuma.transform.CompareTag("Vihollinen"))
                {
                    osuma.transform.GetComponent<VihollisenKuoleminen>().Elämäpisteet -= ampumisLujuus;
                }

            }
            else
            {
                päätePiste = säde.origin + säde.direction * ampumisEtäisyys;
            }
            tykki.SetPositions(new Vector3[] { säde.origin, päätePiste });
            tykki.enabled = true;
            viimeAmpuminen = Time.time;
        }
    }

    void SäteidenLento()
    {
        foreach(LineRenderer tykki in tykit)
        {
            if (!tykki.enabled)
                continue;
            Vector3[] pisteet = new Vector3[2];
            tykki.GetPositions(pisteet);
            pisteet[0] = Vector3.MoveTowards(pisteet[0], pisteet[1], Time.deltaTime * laserSäteenNopeus);
            tykki.SetPositions(pisteet);
            if(Vector3.Distance(pisteet[0], pisteet[1]) < 1f)
            {
                tykki.enabled = false;
            }
        }
    }
}
