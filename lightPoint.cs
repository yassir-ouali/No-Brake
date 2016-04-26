using UnityEngine;
using System.Collections;

public class lightPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//transform.position.z = GameObject.Find ("Sphere").transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position =new Vector3(transform.position.x,transform.position.y, GameObject.Find ("Sphere").transform.position.z);
	}
}
