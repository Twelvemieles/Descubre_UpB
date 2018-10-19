using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPistas : MonoBehaviour {

    public Text pista;
    private string[] pistat = new string[20];

    public int npista;



    // Use this for initialization
    void Start() {
        npista = PlayerPrefs.GetInt("pista");
        pistat[0] = "La próxima pieza del mapa se encuentra donde te ofrecen atención médica.";
        pistat[1] = "La tienda de libros de la universidad.";
        pistat[2] = "De este edificio salen algunos de los mejores abogados del país.";
        pistat[3] = "Libros de todas las carreras y temáticas, si deseas leer alguno solo debes pedirlo.";
        pistat[4] = "La próxima pieza la encontrarás donde muchos carros se encuentran, en varios pisos.";
        pistat[5] = "Si pierdes tu carnet deberás dirigirte a este bloque.";
        pistat[6] = "Una de las entradas de la universidad, la más cercana a la avenida Nutibara.";
        pistat[7] = "La pieza se encuentra en uno de los edificios más nuevos, teniendo laboratorios de todo tipo.";
        pistat[8] = "El mayor espacio deportivo de la universidad.";
        pistat[9] = "El edificio de los especialistas en números.";
        pistat[10] = "El bloque más artístico de la universidad.";
        pistat[11] = "Edificio de posgrados.";
        pistat[12] = "Centro de producción audiovisual.";
        pistat[13] = "Entrada Principal.";
        pistat[14] = "Si deseas hacer parte de un club deportivo, debes pasar por aca.";
        pistat[15] = "Para trabajos de publicidad, acá encontrarás a los especialistas.";
        pistat[16] = "Área donde se reúnen la mayor cantidad de estudiantes.";
        pistat[17] = "Bloque de comunicacion social.";
        pistat[18] = "Donde encontraras al padre rector.";
        pistat[19] = "Entrada 70.";
        PistaActualizar();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("pista", npista);
    }

    public void InicioPista()
    {
        int ran = Random.Range(1, 4);
        if(ran == 1)
        {
            npista = 19;
        }
        if(ran == 2)
        {
            npista = 6;
        }
        if(ran == 3)
        {
            npista = 13;
        }
        PistaActualizar();
    }

    public void PistaActualizar()
    {

        pista.text = pistat[npista];
    }
    public void PistaCompleta()
    {
        if(npista >= 19)
        {
            npista = 0;
        }
        else
        {
            npista += 1;
        }
        PistaActualizar();
    }
}
