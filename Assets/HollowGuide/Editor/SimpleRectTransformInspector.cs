using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SimpleRectTransform))]
[ExecuteInEditMode]
public class SimpleRectTransformInspector : Editor {

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SimpleRectTransform srt = (SimpleRectTransform)target;
		RectTransform rt = srt.transform as RectTransform;
		srt.rectInfo = 
			rt.anchorMin.x + ","
			+ rt.anchorMax.x + ","
			+ rt.anchorMin.y + ","
			+ rt.anchorMax.y + ","
			+ rt.sizeDelta.x + ","
			+ rt.sizeDelta.y + ","
			+ rt.anchoredPosition.x + ","
			+ rt.anchoredPosition.y;
	}
}
