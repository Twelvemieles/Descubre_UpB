using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaSon : MonoBehaviour {
    public DianaMove padre;
    public int vidaDiana = 2, ValorDiana = 2;
    public GameObject destructionPart, hitPart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (vidaDiana <= 0)
        {
            DieDiana();


        }
    }
    private void DieDiana()
    {
        padre.DestroyDiana();
        //Instantiate(destructionPart, transform.position, transform.rotation);

    }
        public void HerirDiana(int Damage)
        {
        vidaDiana -= Damage;
        if (!(vidaDiana <= 0))
        {
            Instantiate(hitPart, transform.position, transform.rotation);
        }
        }
    }
