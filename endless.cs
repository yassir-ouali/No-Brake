using UnityEngine;
using System.Collections;

public class endless : MonoBehaviour {
	public GameObject sphere;
	public Vector3 offset ;
	public Transform t;
	public GameObject basicPlane;

	// Use this for initialization
	void Start () {
		conf.initObstacles ();
		conf.initProduct ();
		conf.readData ();
		resolutionFix ();
		initialise ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canvasScript.start)
		{
			position ();
		}
	}
	void position()
	{
		transform.position =new Vector3(-1.5f,GameObject.Find ("Sphere").transform.position.y,GameObject.Find ("Sphere").transform.position.z)-offset;
	}
	public void initialise()
	{
		GameObject g, c;
		for (int i=0; i<12; i++) {
			g = Instantiate (basicPlane, new Vector3 (0, 0, -3 * Plan.plane), Quaternion.identity) as GameObject;
			g.AddComponent<Plan> ();
			for(int j=0;j<g.transform.GetChild(0).GetComponent<MeshRenderer>().materials.Length;j++){
				g.transform.GetChild(0).GetComponent<MeshRenderer>().materials[j].mainTexture=Resources.Load ("Textures/" + conf.myProducts[conf.selectedTexture].name) as Texture;
			}
			if (!Plan.vide && i>3) {
				int f = (int)Random.Range (0, conf.myObstacles.Count);
				c = Instantiate (GameObject.Find (conf.myObstacles [f].obstacleName), new Vector3 (conf.myObstacles [f].obstaclePosition.x,conf.myObstacles [f].obstaclePosition.y, -3 * Plan.plane),Quaternion.identity) as GameObject;
				c.transform.parent=g.transform;
				c.AddComponent<obstacles>();
				//c.AddComponent<Rigidbody>();
				Plan.vide=true;
			}else{
				Plan.vide=false;
			}
			Plan.plane++;

		}
	}
	void resolutionFix()
	{

		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 5.0f / 3.0f;
		
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();
		
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{
			Rect rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;
			
			Rect rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}
	}


}
