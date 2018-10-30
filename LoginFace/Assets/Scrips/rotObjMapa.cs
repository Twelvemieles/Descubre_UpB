using UnityEngine;
using System.Collections;

public class rotObjMapa : MonoBehaviour
{
    private bool derecha;
    private bool izquierda;

    public void Update()
    {
        if(derecha == true)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 50);
        }

        if (izquierda == true)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 50);
        }
    }

    public void CambiarDerecha()
    {
        derecha = !derecha;
    }

    public void CambiarIzquierda()
    {
        izquierda = !izquierda;
    }
}
