using UnityEngine;
using System.Collections;

public class cubeMove : MonoBehaviour {

	bool left=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		position ();
	}

	void position(){
		if (left) {
			transform.position += transform.GetComponentInParent<Transform>().TransformDirection(new Vector3 (conf.speedCubeMove, 0, 0) )* Time.deltaTime;
		} else {
			transform.position += transform.GetComponentInParent<Transform>().TransformDirection(new Vector3 (-conf.speedCubeMove, 0, 0) )* Time.deltaTime;
		}
		/*if (left) {
			transform.position += new Vector3(transform.GetComponentInParent<Transform>().TransformPoint(new Vector3 (conf.speedCubeMove, 0, 0) ).x,transform.GetComponentInParent<Transform>().TransformPoint(new Vector3 (0, 0, 0) ).y,0)* Time.deltaTime;
		} else {
			transform.position += new Vector3(transform.GetComponentInParent<Transform>().TransformPoint(new Vector3 (-conf.speedCubeMove, 0, 0) ).x,transform.GetComponentInParent<Transform>().TransformPoint(new Vector3 (0, 0, 0) ).x,0)* Time.deltaTime;
		}*/
		//transform.position=(transform.x,,transform.z);
		/*if (left) {
			transform.position+=transform.parent.transform.TransformPoint(new Vector3(conf.speedCubeMove,0,0))* Time.deltaTime;
			//transform.position+=transform.GetComponentInParent<Transform>().TransformVector(new Vector3(-conf.speedCubeMove, 0, 0))* Time.deltaTime;

		} else {
			transform.position+=transform.parent.transform.TransformPoint(new Vector3(-conf.speedCubeMove,0,0))* Time.deltaTime;
			//transform.position += new Vector3(-conf.speedCubeMove,0,0)* Time.deltaTime;
			//transform.position=transform.parent.transform.TransformPoint(transform.position);
			//transform.position+=transform.GetComponentInParent<Transform>().TransformVector(new Vector3(-conf.speedCubeMove, 0, 0))* Time.deltaTime;
		}*/
		if (transform.position.x < transform.GetComponentInParent<Transform>().TransformDirection(new Vector3 (-2.5f, 0, 0) ).x ) {
			left = true;
		} else if(transform.position.x>transform.GetComponentInParent<Transform>().TransformDirection(new Vector3 (-0.5f, 0, 0) ).x) {
			left=false;
		}
	}
}
