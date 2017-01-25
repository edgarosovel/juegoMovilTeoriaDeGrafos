using UnityEngine;
using System.Collections;

public class teclado : MonoBehaviour {

	static public int[,] matriz_jugador;

	public void generar_matriz(){
		int num_nodos = genera_grafo.num_nodos;
		matriz_jugador = new int[num_nodos,num_nodos];
		for (int x = 0; x < num_nodos; x++) {
			for(int y = 0; y < num_nodos; y++){
				matriz_jugador [x,y] = 0;
			}
		}
	}
}
