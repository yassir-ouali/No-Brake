using UnityEngine;
using System.Collections;

public class Plan : MonoBehaviour {

	//public Vector3 planQ;
	Camera cam;
	Plane[] planes;
	Collider objCollider;
	public static int plane=1;
	GameObject g,c,o;
	public GameObject basicPlane;
	public static bool vide = true,first=true;
	// Use this for initialization
	void Start ()
	{
		cam = Camera.main;
		objCollider = GetComponent<Collider> ();

	}

	// Update is called once per frame
	void Update () 
	{
		if (canvasScript.start) 
		{
			//checkInput2();
			endless ();
		}

	}
	void endless()
	{
		planes = GeometryUtility.CalculateFrustumPlanes (cam);
		if (GeometryUtility.TestPlanesAABB (planes, objCollider.bounds) || transform.position.z<= GameObject.Find("Sphere").transform.position.z) {
			//do nothing
		} else {
				Destroy (gameObject);

				g = Instantiate (GameObject.Find("planeBasic"), new Vector3 (0, 0, -3 * Plan.plane), this.transform.rotation) as GameObject;
				g.AddComponent<Plan>();
				for(int j=0;j<g.transform.GetChild(0).GetComponent<MeshRenderer>().materials.Length;j++){
					g.transform.GetChild(0).GetComponent<MeshRenderer>().materials[j].mainTexture=Resources.Load ("Textures/" + conf.myProducts[conf.selectedTexture].name) as Texture;
				}
					if (!vide) {
						int f = (int)Random.Range (0, conf.myObstacles.Count);
					//f=6;
					c = Instantiate (GameObject.Find (conf.myObstacles [f].obstacleName),g.transform.TransformPoint(new Vector3 (conf.myObstacles [f].obstaclePosition.x,conf.myObstacles [f].obstaclePosition.y, -3)),this.transform.rotation) as GameObject;
					c.transform.parent = g.transform;
					//print("aa");	
					c.AddComponent<obstacles>();
					//print("bb");
						Plan.vide = true;
					} else {
						int f2=(int)Random.Range(0,4);
						//f2=0;
						if(f2==0){
							o=Instantiate(GameObject.Find("coin"), new Vector3 (-1, 0.5f, -3 * Plan.plane-3.0f), this.transform.rotation) as GameObject;
						}else if(f2==1){
							o=Instantiate(GameObject.Find("coin"), new Vector3 (-2, 0.5f, -3 * Plan.plane-3.0f), this.transform.rotation) as GameObject;
						}
						Plan.vide = false;
					}
				
				plane++;
				sphere.isTheSame=false;
		}
	}
	void checkInput()
	{
		if(Input.touchCount>0 )
		{
			for(int i=0;i<Input.touchCount;i++){
				if(Input.GetTouch(i).position.x<Screen.width/2)
				{
					this.transform.Rotate(new Vector3(0,0,-conf.speedRotate)*Time.deltaTime);
				}
				else
				{
					this.transform.Rotate(new Vector3(0,0,conf.speedRotate)*Time.deltaTime);
				}
			}
			
		}
		else
		{
			//print (transform.rotation.z);
			if(this.transform.rotation.z>0)
			{
				float target=0;
				float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, target, conf.speedRotate* Time.deltaTime);
				transform.eulerAngles = new Vector3(0, 0,angle);

				if(transform.eulerAngles.z<0){
					transform.eulerAngles = new Vector3(0, 0,0);
				}

			}
			else /*if(this.transform.rotation.z<0)*/
			{
				float s=conf.speedRotate;
				this.transform.Rotate(new Vector3(0,0,s)*Time.deltaTime);
			}

		}
	}

}