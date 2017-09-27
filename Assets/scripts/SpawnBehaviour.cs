using UnityEngine;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour {

	public GameObject[] Enemy = new GameObject[3];
	public GameObject spawn1, spawn2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnNewEnemy (Transform currentPosition) {

		if(currentPosition.position.x > 0f){
			Instantiate(Enemy[Random.Range(0,3)], spawn1.transform.position, Quaternion.identity);
		}else{
			Instantiate(Enemy[Random.Range(0,3)], spawn2.transform.position, Quaternion.identity);
		}

	}
}
