using UnityEngine;
using System.Collections;
using System.Collections.Generic; // *** <-- YOU WILL NEED TO ADD THIS TO USE LISTS.

public class NewObjectPoolerScript : MonoBehaviour {

	public static NewObjectPoolerScript current; // A reference to the current "NewObjectPoolerScriptObject.cs".
	public GameObject pooledObject;              // This is the object we are going to pool.
	public int pooledAmount = 20;                // How many objects will there be in the pool.
	public bool willGrow = true;                 // Can the amount of objects in the pool grow?
	public List<GameObject> pooledObjects;       // This is actually the pool.
	
	void Awake()
	{
		current = this; // Assign it to "this" (a way to reference the current Script).
	}
	
	void Start ()
	{
		pooledObjects = new List<GameObject>();                       // We assign a new List of GameObjects to the "pooledObjects" reference.
		for (int i = 0; i < pooledAmount; i++)                        // Let's build the pool element by element.
		{
			GameObject obj = (GameObject)Instantiate (pooledObject);  // We first instantiate the element to be pooled.
			obj.SetActive(false);                                     // We deactivate it so that it is not showing in the game by default.
			pooledObjects.Add (obj);                                  // Now we push that element to the pool. We are now done.
			pooledObjects[i].name="zombie";                        // This is just the name that will appear on the Hierarchy view (doesn't have any effect on the game).
		}
	}
	
	public GameObject GetPooledObject()                               // This method will allow us to get an object from the pool.
	{
		for (int i = 0; i < pooledObjects.Count; i++)                 // We go over element by element
		{
			
			if (!pooledObjects[i].activeInHierarchy)                  // Is there any object deactivated inside the pool?
			{
				return pooledObjects[i];                              // If so, return that object.
			}
		}
		if (willGrow)                                                 // If this if-condition is reached, that means all objects are active in the game. Shall we create more?
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add (obj);
			return obj;
		}
		
		return null;                                                  // If there are no deactivated elements and we don't wish to grow the pool size, then we return a null object.
	}
}
