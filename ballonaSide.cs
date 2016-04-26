using UnityEngine;
using System.Collections;

public class ballonaSide : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotateTheBallona ();
	}

	void rotateTheBallona(){
		Quaternion qY = Quaternion.AngleAxis (conf.speedBallona*Time.deltaTime,Vector3.up);
			transform.rotation*=qY ;
	}

}
