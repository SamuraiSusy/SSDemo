using UnityEngine;
using System.Collections;

public class SpawnShurikens : MonoBehaviour
{
    public GameObject shurikenPref;
    Shuriken shuriken;

	// Use this for initialization
	void Start ()
    {
        shuriken = GameObject.FindGameObjectWithTag("Shuriken").GetComponent<Shuriken>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(shuriken.destroyed + " shuriken destroyed");
	    if(shuriken.destroyed)
        {

            GameObject g = (GameObject)Instantiate(shurikenPref, new Vector3(0, -4), Quaternion.identity);
            shuriken = g.GetComponent<Shuriken>();
            shuriken.destroyed = false;
        }
	}
}
