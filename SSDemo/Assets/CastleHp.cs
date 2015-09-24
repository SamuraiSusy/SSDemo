using UnityEngine;
using System.Collections;

public class CastleHp : MonoBehaviour
{
     public int hp;
     float time;

	// Use this for initialization
	void Start ()
    {
        hp = 3;
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hp == 0)
        {
            Debug.Log("you lost");
            Application.LoadLevel(0);
            time = 0;
            hp = 3;
        }
	}

   void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy2")
       {
           hp--;
       }
    }
}
