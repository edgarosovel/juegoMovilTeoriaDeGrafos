using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class buttonController : MonoBehaviour {
	public Slider mainSlider;
	public Canvas info;
	public GameObject grafo, canvas1, canvas2, teclado1, teclado2, ganador, wrong;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setNumNodos(){
		genera_grafo.num_nodos = (int)mainSlider.value;
	}

	public void esconde_info(){
		info.GetComponent<CanvasGroup> ().alpha = 0;
		info.GetComponent<CanvasGroup> ().interactable = false;
		info.GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void muestra_info(){
		info.GetComponent<CanvasGroup> ().alpha = 1;
		info.GetComponent<CanvasGroup> ().interactable = true;
		info.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void jugar(){
		grafo.GetComponent<genera_grafo> ().genera_grafica ();
		canvas1.SetActive (false);
		canvas2.SetActive (false);
		teclado1.GetComponent<ScrollableList> ().generarTeclado ();
		teclado2.GetComponent<teclado> ().generar_matriz ();
		teclado2.GetComponent<CanvasGroup> ().alpha = 1;
		teclado2.GetComponent<CanvasGroup> ().interactable = true;
		teclado2.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void comprobar(){
		bool correcto = true;
		int num_nodos = genera_grafo.num_nodos;
		for (int x = 0; x < num_nodos; x++) {
			for(int y = 0; y < num_nodos; y++){
				if(teclado.matriz_jugador[x,y]!=genera_grafo.matriz_adyacencia[x,y])
					correcto=false;
			}
		}
		if (correcto) {
			ganador.GetComponent<CanvasGroup> ().alpha = 1;
			ganador.GetComponent<CanvasGroup> ().interactable = true;
			ganador.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		} else {
			wrong.GetComponent<Animator> ().SetBool ("do",true);	
		}
	}

	public void recargar(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
