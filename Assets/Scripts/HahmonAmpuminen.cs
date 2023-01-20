using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmonAmpuminen : MonoBehaviour
{


    public LineRenderer[] tykit;
    public float ampumisLujuus = 50f;
    public float ampumisEt‰isyys = 12f;
    public float ampumisNopeus = 0.25f;
    public float laserS‰teenNopeus = 40f;
    float viimeAmpuminen;
    int ampumistenLukum‰‰r‰;

    AudioSource ampumis‰‰ni;

    void Start()
    {
        ampumis‰‰ni = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if(Input.GetMouseButton(0) && Time.time - viimeAmpuminen >= ampumisNopeus)
        {
            
            Ammu();
        }
        S‰teidenLento();

        void Ammu()
        {
            ampumis‰‰ni.Play();
            LineRenderer tykki = tykit[++ampumistenLukum‰‰r‰ % 2];
            Ray s‰de = new Ray(tykki.transform.position, tykki.transform.forward);
            RaycastHit osuma;
            Vector3 p‰‰tePiste;
            if(Physics.Raycast(s‰de, out osuma, ampumisEt‰isyys))
            {
                p‰‰tePiste = osuma.point;
                if (osuma.transform.CompareTag("Vihollinen"))
                {
                    osuma.transform.GetComponent<VihollisenKuoleminen>().El‰m‰pisteet -= ampumisLujuus;
                }

            }
            else
            {
                p‰‰tePiste = s‰de.origin + s‰de.direction * ampumisEt‰isyys;
            }
            tykki.SetPositions(new Vector3[] { s‰de.origin, p‰‰tePiste });
            tykki.enabled = true;
            viimeAmpuminen = Time.time;
        }
    }

    void S‰teidenLento()
    {
        foreach(LineRenderer tykki in tykit)
        {
            if (!tykki.enabled)
                continue;
            Vector3[] pisteet = new Vector3[2];
            tykki.GetPositions(pisteet);
            pisteet[0] = Vector3.MoveTowards(pisteet[0], pisteet[1], Time.deltaTime * laserS‰teenNopeus);
            tykki.SetPositions(pisteet);
            if(Vector3.Distance(pisteet[0], pisteet[1]) < 1f)
            {
                tykki.enabled = false;
            }
        }
    }
}
