using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
   
    private float windStrength = 4;
    
    public float radius = 5;
    private int i;
    public float windStrengthMin = 0;
    public float windStrengthMax = 5;
    public Transform rangePosition;
    private Vector3 rotate;
   
    public Collider[] hitColliders;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(rangePosition.position, radius);
    }
    // Use this for initialization
    void Start () {
        rotate = transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
        rotate = Vector3.RotateTowards(transform.forward, rangePosition.position, 100, 0.0f);
        windStrength = Random.Range(windStrengthMin, windStrengthMax);


        hitColliders = Physics.OverlapCapsule(transform.localPosition, rangePosition.position, radius);
            for (i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].GetComponent<Rigidbody>()  != null)
                {
                    hitColliders[i].GetComponent<Rigidbody>().AddForce(rangePosition.forward * windStrength, ForceMode.Acceleration);
                   
                }
            }
        
    }
}
