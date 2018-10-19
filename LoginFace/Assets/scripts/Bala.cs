using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    private Mananger manangerScript;
    private float tLife =  8;
    float t ;
    // Use this for initialization
    void Start () {
        t = 0f;
        manangerScript = FindObjectOfType<Mananger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var diana = collision.gameObject.GetComponent<DianaSon>();
        if (diana != null)
        {
            var Score = diana.ValorDiana;

            manangerScript.SumarPuntaje(Score,transform);
            diana.HerirDiana(1);
            Destroy(gameObject);
        }


       
    }
    // Update is called once per frame
    void Update () {
        
        t = t+Time.deltaTime;
        if (t >= tLife)
        {
            Destroy(gameObject);
        }
	}
}
