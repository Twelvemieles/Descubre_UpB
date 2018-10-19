using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaMove : MonoBehaviour {

    public int vidaDiana = 2,ValorDiana = 2;
    public GameObject destructionPart,hitPart;
    public Transform[] targets;
    private Vector3 inicial, final;
    public int  a = 0 ,b = 1;
    public float  time , elapsedTime;

	// Use this for initialization
	void Start () {
        if (targets.Length > 0)
        {
            inicial = targets[a].localPosition;
            final = targets[b].localPosition;
        }
        else
            inicial = transform.localPosition;
        final = transform.localPosition;



    }
	
	// Update is called once per frame
	void Update () {

      

        if (targets.Length > 0)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition = Vector3.Slerp(inicial, final, elapsedTime / time);



            if (Vector3.Distance(transform.localPosition, final) <= 0.2f)
            {
                CambioPunto();
            }
        }
    }

    private void CambioPunto()
    {
        if (a  == targets.Length - 1)
        {

            a = -1;
        }
        if (targets.Length - 1  == b )
        {
            b = -1;
            
        }
        a++;
        b++;
        inicial = targets[a].localPosition;
        elapsedTime = 0;
        final = targets[b].localPosition;


    }
    public void DestroyDiana()
    {
        Vector3 lugar = new Vector3(transform.position.x, transform.position.y + 12, transform.position.z);
            Instantiate(destructionPart, lugar, transform.rotation);
        Destroy(transform.parent.gameObject);
       
       
    }
    public void HerirDiana(int Damage)
    {
        vidaDiana -= Damage;
        Instantiate(hitPart, transform.position, transform.rotation);
       
    }
}
