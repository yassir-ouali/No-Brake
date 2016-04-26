using UnityEngine;
using System.Collections;

public class sphere : MonoBehaviour {
	
	public static bool isTheSame=false;
	public ParticleSystem particle;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (canvasScript.start) 
		{
			position();
			checkInput2();
			speedHandler();
		}
	}
	void position()
	{
		transform.position += new Vector3 (0, 0,-conf.speedBall * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<obstacles> () != null || other.gameObject.GetComponentInParent<obstacles>() !=null) 
		{
			canvasScript.start = false;

			conf.saveData();
			Plan.plane = 1;
			conf.speedBall=5.5f;
			Application.LoadLevel (Application.loadedLevel);

		}

		if(other.gameObject.tag=="coin")
		{
			/*particle.Stop();
			particle.transform.position=other.transform.position;
			particle.Simulate(3.0f);*/
			Destroy(other.gameObject);
			conf.coins++;
		}
	}
	void checkInput2()
	{
		if (Input.touchCount > 0) {
			for (int i=0; i<Input.touchCount; i++) {
				if(Input.GetTouch(i).position.x<Screen.width/2)
				{
					this.transform.position+=new Vector3((conf.speedBall/3)*Time.deltaTime,0,0);
				}else{
					this.transform.position+=new Vector3(-(conf.speedBall/3)*Time.deltaTime,0,0);
					
				}
			}
		}
	}
	void speedHandler(){

		if((Plan.plane-13)%15==0 && !isTheSame && conf.speedBall<conf.speedMax){
			conf.speedBall+=1;
			isTheSame=true;
		}
	}
}
