
[System.Serializable]
public class product  {

	public bool isBlocked{ get; set;}
	public string name{ get; set;}
	public int cost;
	public product(bool b,string name,int cost){
		isBlocked = b;
		this.name = name;
		this.cost = cost;
	}
	
}
