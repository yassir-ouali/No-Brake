using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class conf : MonoBehaviour{

	public static float speedRotate = 80.0f;
	public static float speedBallona = 60.0f;
	public static float speedBall=6.0f;
	public static float speedMax=11.0f;
	public static float speedCubeMove=1.5f;
	public static List<obstacles> myObstacles = new List<obstacles> (); 
	public static List<product> myProducts = new List<product>();
	public static int selectedTexture =1;
	public static int topScore=0;
	public static int coins=0;

	public static void initObstacles(){
		myObstacles.Add (new obstacles ("left", new Vector3 (-0.78f, 0.214f, -3 * Plan.plane)));
		myObstacles.Add (new obstacles ("right", new Vector3 (-2.2f, 0.214f, -3 * Plan.plane)));
		myObstacles.Add (new obstacles ("middle", new Vector3 (-1.5f, 0.215f, (-3 * Plan.plane) - 1.5f)));
		myObstacles.Add (new obstacles ("left-right", new Vector3 (-0.6f, 0.214f, (-3 * Plan.plane) - 1.5f)));
		myObstacles.Add (new obstacles ("cubeMove", new Vector3 (-0.5f, 0.215f, (-3 * Plan.plane) - 1.5f)));
		myObstacles.Add (new obstacles ("ballonaSide", new Vector3 (-1.5f,0.3f, (-3 * Plan.plane) - 1.5f)));
		myObstacles.Add (new obstacles ("ballonaTop", new Vector3 (-1.5f,0.3f, (-3 * Plan.plane) - 1.5f)));
	}

	public static void initProduct(){
		if (myProducts.Count == 0)
		{
			myProducts.Add (new product (false, "red", 0));
			myProducts.Add (new product (false, "blue", 00));
			myProducts.Add (new product (false, "green", 0));

			myProducts.Add (new product (true, "red_diamond", 100));
			myProducts.Add (new product (true, "blue_diamond", 100));
			myProducts.Add (new product (true, "green_diamond", 100));

			myProducts.Add (new product (true, "red_checker", 100));
			myProducts.Add (new product (true, "blue_checker", 100));
			myProducts.Add (new product (true, "green_checker", 100));

			myProducts.Add (new product (true, "red_stripe", 100));
			myProducts.Add (new product (true, "blue_stripe", 100));
			myProducts.Add (new product (true, "green_stripe", 100));
		}
	}

	public static void saveData(){
		gameData d = new gameData ();
		if (conf.topScore < (Plan.plane - 13)) {
			conf.topScore = Plan.plane - 13;
		}
		
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames2.gd"); //you can call it anything you want
		d.score = conf.topScore;
		for (int i=0; i<conf.myProducts.Count; i++) {
			d.products.Add(conf.myProducts [i]);
		}
		d.selectedTexture = conf.selectedTexture;
		d.coins = conf.coins;
		bf.Serialize(file, d);
		file.Close();

	}
	public static void readData()
	{
		
		List<product> prod = new List<product> ();
		if (File.Exists (Application.persistentDataPath + "/savedGames2.gd")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/savedGames2.gd", FileMode.Open);
			gameData gd=((gameData)bf.Deserialize (file));
			file.Close ();

			prod = gd.products;
			conf.topScore=gd.score;
			conf.selectedTexture=gd.selectedTexture;
			conf.coins=gd.coins;
			for (int i=0; i<conf.myProducts.Count; i++){
					conf.myProducts [i].isBlocked = prod[i].isBlocked;
			}
		} else {
			conf.saveData();
			conf.readData();
		}
	}
}
