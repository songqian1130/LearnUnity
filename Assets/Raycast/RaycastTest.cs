using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Ray ray = new Ray(transform.position, transform.forward);

		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 500))

		{

			//打印碰撞信息 

			print(hit.collider.name);

			//画线，使其射线可视化。 

			Debug.DrawLine(transform.position, hit.point, Color.red, 100);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
