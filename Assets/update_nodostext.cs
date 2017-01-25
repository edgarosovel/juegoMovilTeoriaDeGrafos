using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class update_nodostext : MonoBehaviour {

	Text texto;
	void Start () {
		texto = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		texto.text = "numero de nodos: " + genera_grafo.num_nodos.ToString();
	}
}
