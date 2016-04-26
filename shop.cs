using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class shop : MonoBehaviour {

	gameData data;
	public GUIContent scrollView;
	float w;
	float h;
	// Use this for initialization
	void Start () {
		w = Screen.width;
		h = Screen.height;

		data = new gameData ();
		conf.initProduct ();
		conf.readData ();
		drawShop ();
	}
	
	// Update is called once per frame
	void Update () {
		checkSelecting ();
	}
	void drawShop(){
		//draw the products

		adjustPanel ();

		//int j = 0;
		for (int i=0;i<conf.myProducts.Count;i++) {
			GameObject d=new GameObject(conf.myProducts[i].name);
			var rect=d.AddComponent<RectTransform>();//=//new Rect (,);
			//rect.transform.position=new Vector2(w/5*(i%3)+w/10*(i%3+1),h/3+w/5*(i/3)+w/10*(i/3+1));
			float headerY=Screen.height;
			float racineY=Screen.height;
			rect.transform.position=new Vector2(w/5*(i%3)+w/10*(i%3+2),h/3-w/5*(i/3)-w/10*(i/3+1)+racineY/5);
			rect.sizeDelta=new Vector2(w/5, w/5);
			d.AddComponent<CanvasRenderer>();
			if(!conf.myProducts[i].isBlocked){
				d.AddComponent<RawImage>().texture=Resources.Load ("Textures/" + conf.myProducts[i].name) as Texture;
			}else{
				d.AddComponent<RawImage>().texture=Resources.Load ("Textures/lock-10") as Texture;
				GameObject t=new GameObject();
				var text=t.AddComponent<Text>();
				text.text=conf.myProducts[i].cost+"$";
				text.color=Color.black;

				text.font=Font.CreateDynamicFontFromOSFont("Arial",22);
				t.transform.position=d.transform.position;
				t.GetComponent<RectTransform>().sizeDelta=new Vector2(w/5, w/20);
				text.resizeTextForBestFit=true;
				text.alignment=TextAnchor.UpperCenter;
				text.transform.position+=new Vector3(0,-w/8,0);
				t.transform.SetParent(d.transform);

			}
			if(i==conf.selectedTexture){
				var outline=d.AddComponent<Outline>();
				outline.effectColor=Color.black;
				outline.effectDistance=new Vector2(2f,2f);
			}
			print("aaaaaaa");
			d.transform.SetParent(GameObject.Find("panelScroll").transform);//parent=GameObject.Find("panelScroll").transform;
		}
	}
	
	public void checkSelecting(){
		List<RaycastResult> raycastresult = new List<RaycastResult> ();
		if (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Ended) {
			PointerEventData pointer = new PointerEventData (EventSystem.current);
			//pointer.position = Input.GetTouch (0).position;
			pointer.position = Input.mousePosition;
			EventSystem.current.RaycastAll (pointer, raycastresult);
			if (raycastresult.Count > 0) {
				for (int i=0; i<conf.myProducts.Count; i++) {
					if (raycastresult [0].gameObject.name.Equals(conf.myProducts[i].name)){
						print(i+""+conf.myProducts.Count);
						if(!conf.myProducts[i].isBlocked){
							if(conf.selectedTexture!=i){
								selectTexture (i);
								reDrawBorder(conf.myProducts[i].name);
								redrawPlanTexture();
							}
						}else{
							if(conf.coins>=conf.myProducts[i].cost){
								conf.coins-=conf.myProducts[i].cost;
								deblockProduct(i);
								selectTexture (i);
								reDrawBorder(conf.myProducts[i].name);
								redrawPlanTexture();
							}
						}
					}
				}
			}
		}
	}

	public void selectTexture(int i){
		conf.selectedTexture = i;
	}

	public void deblockProduct(int i){
		conf.myProducts [i].isBlocked = false;
		GameObject.Find("panelScroll").transform.GetChild(i+1).gameObject.GetComponent<RawImage>().texture=Resources.Load ("Textures/" + conf.myProducts[i].name) as Texture;
		Destroy(GameObject.Find("panelScroll").transform.GetChild(i+1).gameObject.transform.GetChild(0));
	}

	public void reDrawBorder(string n)
	{

		for(int j=0;j<GameObject.Find("panelScroll").transform.childCount;j++) {
			if(GameObject.Find("panelScroll").transform.GetChild(j).GetComponent<Outline>()!=null){

				Destroy(GameObject.Find("panelScroll").transform.GetChild(j).GetComponent<Outline>());
			}
			if(n.Equals(GameObject.Find("panelScroll").transform.GetChild(j).name)){
				var outline=GameObject.Find("panelScroll").transform.GetChild(j).gameObject.AddComponent<Outline>();
				outline.effectColor=Color.black;
				outline.effectDistance=new Vector2(2f,2f);
			}
		}
	}
	public void redrawPlanTexture()
	{
		foreach (GameObject g in GameObject.FindGameObjectsWithTag ("plan")) {
			for (int j=0; j<g.transform.GetChild(0).GetComponent<MeshRenderer>().materials.Length; j++) {
				g.transform.GetChild (0).GetComponent<MeshRenderer> ().materials [j].mainTexture = Resources.Load ("Textures/" + conf.myProducts [conf.selectedTexture].name) as Texture;
			}
		}
	}

	public void adjustPanel(){
		float height = (conf.myProducts.Count / 3) * w*2 / 8;
		GameObject.Find ("panelScroll").GetComponent<RectTransform> ().transform.position -=new Vector3(0,height / 2,0);
		GameObject.Find ("panelScroll").GetComponent<RectTransform> ().sizeDelta = new Vector2 (GameObject.Find ("panelScroll").GetComponent<RectTransform> ().sizeDelta.x,height);

	}
}
