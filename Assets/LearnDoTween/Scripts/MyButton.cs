using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MyButton : MonoBehaviour
{

	public RectTransform rectTransform;

	private bool isIn = false;

	void Start()
	{
		Tweener tweener = rectTransform.DOLocalMove(new Vector3(0, 0, 0), 1);
		tweener.SetAutoKill(false);
		tweener.Pause();
	}

	public void OnClick()
	{
		if (!isIn)
		{
			isIn = true;
			rectTransform.DOPlayForward();
		}
		else
		{
			isIn = false;
			rectTransform.DOPlayBackwards();
		}
	}
}
