using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI 의 최소단위는 Canvas 단위로 구분할것이기 때문에
// UIMonoBehaviour 는 Canvas 컴포넌트가 필요함
[RequireComponent(typeof(Canvas))]
public class UIMonoBehaviour : MonoBehaviour, IUI
{
    public int sortOrder
    {
        get => canvas.sortingOrder;
        set => canvas.sortingOrder = value;
    }

    protected Canvas canvas;
    protected UIManager manager;

    public event Action onShow;
    public event Action onHide;

    /// <summary>
    /// 이 UI 활성화
    /// </summary>
    public void Show()
    {
        manager.Push(this); // 매니저한테 이거 젤 위에다가 띄워달라고 함.
        gameObject.SetActive(true);
        onShow?.Invoke();
    }

    /// <summary>
    /// 이 UI 비활성화
    /// </summary>
    public void Hide()
    {
        manager.Pop(this); // 매니저한테 이거 빼달라고 함.
        gameObject.SetActive(false);
        onHide?.Invoke();
    }

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        manager = UIManager.instance;
        manager.Register(this);
    }
}
