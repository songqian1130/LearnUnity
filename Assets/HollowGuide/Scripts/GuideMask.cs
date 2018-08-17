using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GuideMask : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

	[SerializeField]
	Image image;
	[SerializeField]
	Animator animator;
	[SerializeField]
	Transform ArrowParent;

	//最终的偏移
	private float targetOffsetX = 0f;
	private float targetOffsetY = 0f;
	//当前的偏移
	private float currentOffsetX = 0f;
	private float currentOffsetY = 0f;

	//Canvas
	Canvas canvas;

	//材质
	private Material material;

	//当前点击的按钮
	private GameObject currentPress;

	void Awake()
	{
		canvas = transform.parent.GetComponent<Canvas>();
		material = GetComponent<Image>().material;
		//需要在创建的时候就初始化
		material.SetFloat("_SliderX", 0);
		material.SetFloat("_SliderY", 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Home))
		{
			SetRectAnchorAndPos(0.5f, 0.5f, 0.5f, 0.5f, 200f, 100f, 0, 0);
			Show();
		}
		//这里特别处理一下被点击的按钮响应IPointerExit事件的问题，按钮被点击缩小以后接收不了Exit事件不会还原大小，
		//这是因为Mask在上层，Enter和Exit事件都传不下去，事件渗透只处理的点击相关的事件
		JudgePointerExit();
	}

	/// <summary>
	/// 判断当前屏幕位置是否离开该被点击的物体
	/// </summary>
	private void JudgePointerExit()
	{
		Vector3 screenPosition = Input.mousePosition;
		if (currentPress != null && !IsPointerOverUIObject(canvas, screenPosition, currentPress))
		{
			PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
			eventDataCurrentPosition.position = screenPosition;
			ExecuteEvents.Execute(currentPress, eventDataCurrentPosition, ExecuteEvents.pointerExitHandler);
			currentPress = null;
		}
	}

	/// <summary>
	/// 判断屏幕hover位置是否在目标UI上
	/// </summary>
	/// <param name="canvas"></param>
	/// <param name="screenPosition"></param>
	/// <param name="go"></param>
	private bool IsPointerOverUIObject(Canvas canvas, Vector2 screenPosition, GameObject go)
	{
		PointerEventData data = new PointerEventData(EventSystem.current);
		data.position = screenPosition;
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(data, results);
		return results.Where(v => v.gameObject == go).Count() > 0;
	}

	public void Show()
	{
		Vector3[] corners = new Vector3[4];

		//获取高亮区域四个顶点坐标
		image.rectTransform.GetWorldCorners(corners);
		//计算高亮区域在画布中的范围
		targetOffsetX = Vector2.Distance(WorldToCanvasPos(canvas, corners[0]), WorldToCanvasPos(canvas, corners[3])) / 2f;
		targetOffsetY = Vector2.Distance(WorldToCanvasPos(canvas, corners[0]), WorldToCanvasPos(canvas, corners[1])) / 2f;
		//计算高亮区域的中心
		float x = corners[0].x + (corners[3].x - corners[0].x) / 2f;
		float y = corners[0].y + (corners[1].y - corners[0].y) / 2f;

		Vector3 centerWorld = new Vector3(x, y, 0);

		//TODO 指示手的代码可以加在这里

		Vector2 center = WorldToCanvasPos(canvas, centerWorld);
		//设置遮罩材质的Center
		Vector4 centerMat = new Vector4(center.x, center.y, 0, 0);
		material.SetVector("_Center", centerMat);

		RectTransform canvasRectTransform = canvas.transform as RectTransform;
		if (canvasRectTransform != null)
		{
			//获取画布区域的顶点坐标
			canvasRectTransform.GetWorldCorners(corners);
			//求偏移初始值
			currentOffsetX = Mathf.Max(Vector3.Distance(WorldToCanvasPos(canvas, corners[0]), center), currentOffsetX);
			currentOffsetX = Mathf.Max(Vector3.Distance(WorldToCanvasPos(canvas, corners[2]), center), currentOffsetX);
			currentOffsetY = Mathf.Max(Vector3.Distance(WorldToCanvasPos(canvas, corners[1]), center), currentOffsetY);
			currentOffsetY = Mathf.Max(Vector3.Distance(WorldToCanvasPos(canvas, corners[3]), center), currentOffsetY);
		}
		material.SetFloat("_SliderX", targetOffsetX);
		material.SetFloat("_SliderY", targetOffsetY);

		animator.gameObject.SetActive(true);
		animator.SetTrigger("ShowAnim");
	}

	/// <summary>
	/// 世界坐标转画布坐标
	/// </summary>
	/// <param name="canvas"></param>
	/// <param name="world"></param>
	/// <returns>画布坐标</returns>
	Vector2 WorldToCanvasPos(Canvas canvas, Vector3 world)
	{
		Vector2 position;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
		return position;
	}

	/// <summary>
	/// 设置矩形锚点和坐标
	/// </summary>
	/// <param name="anchorMinX"></param>
	/// <param name="anchorMaxX"></param>
	/// <param name="anchorMinY"></param>
	/// <param name="anchorMaxY"></param>
	/// <param name="sizeDeltaX"></param>
	/// <param name="sizeDeltaY"></param>
	/// <param name="anchorPosX"></param>
	/// <param name="anchorPosY"></param>
	public void SetRectAnchorAndPos(float anchorMinX, float anchorMaxX, float anchorMinY, float anchorMaxY, float sizeDeltaX, float sizeDeltaY, float anchorPosX, float anchorPosY)
	{
		image.rectTransform.anchorMin = new Vector2(anchorMinX, anchorMinY);
		image.rectTransform.anchorMax = new Vector2(anchorMaxX, anchorMaxY);
		image.rectTransform.sizeDelta = new Vector2(sizeDeltaX, sizeDeltaY);
		image.rectTransform.anchoredPosition = new Vector2(anchorPosX, anchorPosY);
	}

	/// <summary>
	/// 监听进入
	/// </summary>
	/// <param name="eventData"></param>
	public void OnPointerEnter(PointerEventData eventData)
	{
		PassEvent(eventData, ExecuteEvents.pointerEnterHandler);
	}

	/// <summary>
	/// 监听离开
	/// </summary>
	/// <param name="eventData"></param>
	public void OnPointerExit(PointerEventData eventData)
	{
		PassEvent(eventData, ExecuteEvents.pointerExitHandler);
	}

	/// <summary>
	/// 监听按下
	/// </summary>
	/// <param name="eventData"></param>
	public void OnPointerDown(PointerEventData eventData)
	{
		PassEvent(eventData, ExecuteEvents.pointerDownHandler);
	}

	/// <summary>
	/// 监听抬起
	/// </summary>
	/// <param name="eventData"></param>
	public void OnPointerUp(PointerEventData eventData)
	{
		PassEvent(eventData, ExecuteEvents.pointerUpHandler);
	}

	/// <summary>
	/// 监听点击
	/// </summary>
	/// <param name="eventData"></param>
	public void OnPointerClick(PointerEventData eventData)
	{
		PassEvent(eventData, ExecuteEvents.submitHandler);
		PassEvent(eventData, ExecuteEvents.pointerClickHandler);
	}

	/// <summary>
	/// 事件渗透
	/// </summary>
	/// <param name="data"></param>
	/// <param name="function"></param>
	void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function) where T : IEventSystemHandler
	{
		//判断是否在矩形区域内，如果是离开事件也允许渗透，主要是为了应对按钮被按下放开，缩小放大的问题
		if (!RectTransformUtility.RectangleContainsScreenPoint(image.rectTransform, data.position, data.enterEventCamera)) return;

		//新手点击响应
		if (function.Equals(ExecuteEvents.pointerUpHandler)) ;
			//TutorialManager.Instance.FinishCurrentGuide(true);
			//TODO 新手点击回调事件可以加在这里

		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(data, results);

		GameObject current = data.pointerCurrentRaycast.gameObject;
		foreach (RaycastResult result in results)
		{
			//如果是自己，继续找下一个
			if (result.gameObject == current) continue;
			if (function.Equals(ExecuteEvents.pointerDownHandler)) currentPress = result.gameObject;
			//转播事件，只响应第一个事件
			if (ExecuteEvents.Execute(result.gameObject, data, function)) break;
		}
	}
}
