using UnityEngine;

public class obstacles  :MonoBehaviour{
	public string obstacleName;
	public Vector3 obstaclePosition;


	public obstacles(string n,Vector3 v){
		obstacleName = n;
		obstaclePosition = v;
	}

}
