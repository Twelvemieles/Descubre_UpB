using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioScena : MonoBehaviour
{
    bool activar;
    public GameObject mapa;

	public void Habilitar()
    {
        mapa.SetActive(true);

    }
}
