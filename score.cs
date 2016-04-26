using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		printScore ();
	}
	void printScore(){
		text.text=(Plan.plane-13>=0?Plan.plane-13:0)+"/"+conf.topScore;
	}

}
