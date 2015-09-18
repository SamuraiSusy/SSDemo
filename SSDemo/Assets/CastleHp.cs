using UnityEngine;
using System.Collections;

public class CastleHp : MonoBehaviour
{
     int hp;

	// Use this for initialization
	void Start ()
    {
        hp = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hp == 0)
            Debug.Log("you lost");
	}

   void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Enemy")
       {
           hp--;
       }
    }
}
