using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    public GameObject itemPrefab;
    int itemCount, columnCount ;

    void Start(){
    }

	public void generarTeclado(){
		
		itemCount = columnCount= genera_grafo.num_nodos+1; 
		RectTransform rowRectTransform = itemPrefab.GetComponent<RectTransform>();
		RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

		//calculate the width and height of each child item.
		float width = containerRectTransform.rect.width / columnCount;
		float ratio = width / rowRectTransform.rect.width;
		float height = rowRectTransform.rect.height * ratio;
		int rowCount = itemCount;

		//adjust the height of the container so that it will just barely fit all its children
		float scrollHeight = height * rowCount;
		//containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
		//containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);

		int aux = 0;
		for (int i = 0; i < itemCount; i++)
		{
			for(int j = 0; j< columnCount; j++){
				//this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns

				//create a new item, name it, and set the parent
				GameObject newItem = Instantiate(itemPrefab) as GameObject;
				newItem.name = "item(" + i + "," + j + ")";
				//newItem.name = "item"+i;
				newItem.transform.SetParent (gameObject.transform, false);
				//move and size the new item
				RectTransform rectTransform = newItem.GetComponent<RectTransform>();

				float x = -containerRectTransform.rect.width / 2 + width * (i % columnCount);
				float y = containerRectTransform.rect.height / 2 - height * j-height*0.83f;
				rectTransform.offsetMin = new Vector2(x, y);

				x = rectTransform.offsetMin.x + width;
				y = rectTransform.offsetMin.y + height;
				rectTransform.offsetMax = new Vector2(x, y);

				string tipo;
				if (i == 0 && j == 0) {
					tipo = "X";
				} else if (i == 0) {
					tipo = (j).ToString ();
				}
				else if(j==0){
					tipo = (i).ToString ();
				}
				else{
					tipo= "boton";
				}

				newItem.GetComponent<controlador>().init_button(i,j,tipo);
			}
		}
	}

}
