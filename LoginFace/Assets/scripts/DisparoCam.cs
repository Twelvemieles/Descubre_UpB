
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoCam : MonoBehaviour {
    public Rigidbody[] balaPrefab;
    public Transform shootPoint;
    public float fuerza;
    private Mananger manangerScript;
    //public GameObject imageTarget;




    public float timeShoot =  0.5f ;
    

	// Use this for initialization
	void Start () {
        manangerScript = FindObjectOfType<Mananger>();
    }
	
	// Update is called once per frame
	void Update () {
        timeShoot += Time.deltaTime;
       if ( Input.GetMouseButtonUp(0) && !manangerScript.muyCerca )

        {
            if (timeShoot > 0.3f)
            {
                Disparo();
            }
            
           
            
        }
        
	}

    private void Disparo()
    {

        if (manangerScript.gameOver == false)
        {
            timeShoot = 0;
            var bullet = Instantiate(balaPrefab[Random.Range(0,balaPrefab.Length)],shootPoint.position, shootPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * fuerza;
            bullet.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-fuerza, fuerza), Random.Range(-fuerza,fuerza), Random.Range(-fuerza, fuerza)));
        }
       
    }
}
