using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmonOhjaus : MonoBehaviour
{
    
    Rigidbody rb;
    Animator animaattori;
    public float liikkumisNopeus = 2.5f;
    public float k‰‰ntymisNopeus = 200f;
    public Transform yl‰osa;
    public LayerMask s‰teenVaikutus;
    private bool isJumping;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animaattori = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        float pystysuora = Input.GetAxisRaw("Vertical");
        Vector3 siirtym‰ = transform.forward * pystysuora * liikkumisNopeus * Time.deltaTime;
        rb.MovePosition(transform.position + siirtym‰);


        float vaakasuora = Input.GetAxisRaw("Horizontal");
        Quaternion k‰‰ntym‰ = Quaternion.Euler(0, vaakasuora * k‰‰ntymisNopeus * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * k‰‰ntym‰);

        animaattori.SetBool("k‰velee", pystysuora != 0 || vaakasuora !=0);

        
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector3.up * 300);
            isJumping = true;
        }

        if (Time.timeScale == 0)
            return;
       
        Ray s‰de = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit osuma;
        if(Physics.Raycast(s‰de, out osuma, 100, s‰teenVaikutus))
        {
            Vector3 katsomisSuunta = osuma.point - transform.position;
            katsomisSuunta.y = 0;
            yl‰osa.rotation = Quaternion.LookRotation(katsomisSuunta);

        }

    }

     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Maa"))
        {
            isJumping = false;
        }
    }


}
