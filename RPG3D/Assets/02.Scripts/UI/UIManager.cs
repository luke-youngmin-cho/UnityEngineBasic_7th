using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBase<UIManager>
{
    public Dictionary<Type, IUI> uis = new Dictionary<Type, IUI>();
    public LinkedList<IUI> uisShown = new LinkedList<IUI>();

    public void Register(IUI ui)
    {
        if (uis.TryAdd(ui.GetType(), ui) == false)
            throw new Exception($"[UIManager] : Failed to register {ui.GetType()}");
    }

    /// <summary>
    ///  원하는 타입의 UI 를 받아올때 사용
    ///  ex)
    ///  if (UIManager.instance.TryGet(out InventoryUI ui)
    ///  {
    ///        // Do something with InventoryUI
    ///  }
    /// </summary>
    public bool TryGet<T>(out T ui)
        where T : IUI
    {
        if (uis.TryGetValue(typeof(T), out IUI value))
        {
            ui = (T)value;
            return true;
        }

        ui = default;
        return false;
    }

    public void Push(IUI ui)
    {
        // 이미 해당 ui 가 가장 마지막에 있으면 Push 할필요 없음
        if (uisShown.Count > 0 &&
            uisShown.Last.Value == ui)
            return;

        int sortOrder = 0;
        // 기존에 열린 ui 가 있으면 가장 마지막에있는 ui 보다 더 큰 sortOrder로 세팅해야함.
        if (uisShown.Last != null)
        {
            sortOrder = uisShown.Last.Value.sortOrder + 1;
        }
        ui.sortOrder = sortOrder;
        uisShown.Remove(ui);
        uisShown.AddLast(ui);
    }

    public void Pop(IUI ui)
    {
        uisShown.Remove(ui);
    }

    public void HideLast()
    {
        // 현재 활성화된 UI 가 하나두 없으면 리턴
        if (uisShown.Count <= 0) 
            return;

        // 활성화된UI들중.마지막.UI를.숨긴다();
        uisShown.Last.Value.Hide();
    }
}
