using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField]
    private int force;

    private bool tocado;
    private Rigidbody rb;

    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update ()
    {
        rb.AddForce(transform.forward * force);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("destruir", 1.5f);
        }
    }

    public void destruir()
    {
        Destroy(this.gameObject);
    }

}
