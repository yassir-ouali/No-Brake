using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour {

	Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		printCoins ();
	}

	void printCoins(){
		text.text=conf.coins+"$";
	}

}
