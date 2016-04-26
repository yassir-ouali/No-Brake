using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class canvasScript : MonoBehaviour {

	public static bool start=false;
	public GameObject MenuCanvas;
	public GameObject HelpCanvas;
	public GameObject AboutCanvas;
	public GameObject scoreCanvas;
	public GameObject shopCanvas;
	// Use this for initialization
	void Start () {

	}

	
	// Update is called once per frame
	void Update () 
	{
		checkInput ();
	}
	public void checkInput()
	{
		if (!Application.isShowingSplashScreen) 
		{
			List<RaycastResult> raycastresult = new List<RaycastResult> ();
			if (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Ended) {
				PointerEventData pointer = new PointerEventData (EventSystem.current);
				//pointer.position = Input.GetTouch (0).position;
				pointer.position = Input.mousePosition;
				EventSystem.current.RaycastAll (pointer, raycastresult);
				if (raycastresult.Count > 0) {
					//for (int i=0; i<raycastresult.Count; i++) {
						if (raycastresult [0].gameObject.name == "help" || raycastresult [0].gameObject.name == "backHelp"){
							help ();
							return ;
						}else if (raycastresult [0].gameObject.name == "about" || raycastresult [0].gameObject.name == "backAbout"){
							about ();
							return ;
						}else if (raycastresult [0].gameObject.name == "shop" || raycastresult [0].gameObject.name == "backShop"){
							shop ();
							return ;
						}
						else
						{
							if(!HelpCanvas.activeInHierarchy && !AboutCanvas.activeInHierarchy && MenuCanvas.activeInHierarchy){
								MenuCanvas.SetActive(false);
								scoreCanvas.SetActive(true);
								start = true;
							}
						}
					}

				//}

			}
		}

	}
	public void about()
	{
		MenuCanvas.SetActive(!MenuCanvas.activeInHierarchy);
		AboutCanvas.SetActive (!AboutCanvas.activeInHierarchy);
	}

	public void help()
	{
		MenuCanvas.SetActive(!MenuCanvas.activeInHierarchy);
		HelpCanvas.SetActive (!HelpCanvas.activeInHierarchy);
	}
	public void shop()
	{

		//if (shopCanvas.activeInHierarchy) {
			conf.saveData();
		//}

		MenuCanvas.SetActive(!MenuCanvas.activeInHierarchy);
		shopCanvas.SetActive (!shopCanvas.activeInHierarchy);
	}
}
