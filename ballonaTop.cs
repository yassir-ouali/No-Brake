using UnityEngine;
using System.Collections;

public class ballonaTop : MonoBehaviour {

	bool right=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotateTheBallona ();
	}

	void rotateTheBallona(){
		Quaternion qY = Quaternion.AngleAxis (2*conf.speedBallona*Time.deltaTime,Vector3.forward);

		if (right) {
			transform.rotation*=qY ;
		} else {
			transform.rotation*=Quaternion.Inverse(qY);
		}
		
		

		if( transform.localEulerAngles.z>170){
			right=false;
		}else if(transform.localEulerAngles.z<10){
			right=true;
		}


		
	}
}
