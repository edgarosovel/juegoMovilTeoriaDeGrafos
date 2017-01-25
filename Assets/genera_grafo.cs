using UnityEngine;
using System.Collections;

public class genera_grafo : MonoBehaviour {
	public GameObject nodo, flecha;
	static public int num_nodos=3;
	GameObject newNodo, newFlecha;
	int grados;
	static public int[,] matriz_adyacencia;

	void Start () {
		
	}

	public void genera_grafica(){
		matriz_adyacencia = new int[num_nodos,num_nodos];
		for (int x = 0; x < num_nodos; x++) {
			for(int y = 0; y < num_nodos; y++){
				matriz_adyacencia [x,y] = (Random.Range (0,6)==0?1:0);
			}
		}
		for (int x = 0; x < num_nodos; x++) {
			for(int y = 0; y < num_nodos; y++){
				if (x == y) {
					matriz_adyacencia [y, x] = 0;
				}
				if (matriz_adyacencia [x, y] == 1) {
					matriz_adyacencia [y, x] = 1;	
				}
			}
		}
		grados = 360 / num_nodos;
		for (int i = 0; i < num_nodos; i++) {
			newNodo = Instantiate(nodo, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			newNodo.transform.SetParent(transform, false);
			newNodo.transform.localPosition = new Vector3 (Mathf.Cos (i * grados * Mathf.Deg2Rad), Mathf.Sin (i * grados * Mathf.Deg2Rad), 0);
			newNodo.transform.GetChild (0).GetComponent<TextMesh> ().text = (i + 1).ToString();
			LineRenderer linea = newNodo.GetComponent<LineRenderer> ();
			Vector3 origen = newNodo.transform.position;
			int vertices = 0;
			linea.SetVertexCount (vertices);
			linea.SetWidth (0.02f,0.02F);
			int z = 0;
			for(int y = 0; y < num_nodos; y++){
				if (matriz_adyacencia [i,y] == 1) {
					vertices += 3;
					linea.SetVertexCount (vertices);

					linea.SetPosition (z,origen);
					z++;
					linea.SetPosition (z,(new Vector3 (Mathf.Cos (y * grados * Mathf.Deg2Rad), Mathf.Sin (y * grados * Mathf.Deg2Rad), 0)+transform.position));
					z++;
					linea.SetPosition (z,origen);
					z++;
				}
			}
		}
	}

	void Update () {
	
	}
}
