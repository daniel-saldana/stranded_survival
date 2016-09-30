using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour 

{

	bool isSpawning = false;

	public float minTime = 5.0f;
	public float maxTime = 15.0f;

	//Was working on a range for spawning area. Not sure what to do, could do an Array for this as well?
	/*public float MinX = -200;
	public float MaxX = 200;
	public float MinZ = -200;
	public float MaxZ = 200;*/

	//An Array to pick spawnable Enemies and/or Resources.
	public GameObject[] spawnables; 

	IEnumerator SpawnObject(int index, float seconds)
	{
		Debug.Log ("Waiting for " + seconds + " seconds");

		yield return new WaitForSeconds(seconds);
		Instantiate (spawnables[index], transform.position, transform.rotation);
		isSpawning = false;
	}
	void Update ()
	{
		if (! isSpawning) 
		{
			isSpawning = true;
			int spawnIndex = Random.Range(0, spawnables.Length);
			StartCoroutine(SpawnObject(spawnIndex, Random.Range(minTime, maxTime)));
		}
	}
		
	/*void SpawnableInstantiate() 
	{
		float x = Random.Range(MinX,MaxX);
		float z = Random.Range(MinZ,MaxZ);

		Instantiate (spawnables, new Vector3(x, 0.5, z), Quaternion.identity);
	}*/
}