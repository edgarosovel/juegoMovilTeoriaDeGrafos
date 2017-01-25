using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controlador : MonoBehaviour {

	int x,y,num;

	public void cambiar_valor(){
		num = (teclado.matriz_jugador[x-1,y-1]==1)?0:1;
		teclado.matriz_jugador[x-1,y-1]=num;
		GameObject.Find("item("+x.ToString()+","+y.ToString()+")").transform.GetChild (0).GetComponent<Text> ().text = num.ToString();
	}

	public void init_button(int x, int y, string tipo){
		this.x = x;
		this.y = y;
		if (tipo != "boton") {
			GetComponent<Button> ().enabled = false;
			GetComponent<Image> ().enabled = false;
			transform.GetChild (0).GetComponent<Text> ().text = tipo;
		}
	}
}
