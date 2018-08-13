using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class mytext : MonoBehaviour
{
	private Text text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text>();
		text.DOText("愿圣光保佑你", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
