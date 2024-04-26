using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualElementExtern
{
    internal class Radio : Button
    {
        private Label label;
        private VisualElement selectPanel;
        public Radio()
        {
            text = " ";
            selectPanel = new VisualElement();
            selectPanel.StretchToParentSize();
            Add(selectPanel);
            selectPanel.style.backgroundColor = new Color(70/255f, 130/255f, 180/255f, 1);
            label = new Label();
            Add(label);
        }

        public void SetLabel(string text)
        {
            label.text = text;
        }

        public void SetSelected(bool selected)
        {
            selectPanel.visible = selected;
        }
    }

    public class RadioButtonList : VisualElement
    {
        private List<Radio> buttons = new List<Radio>();
        public System.Action<string> OnSelect;
        public System.Action<GenericMenu, string> OnElementMenu;

        public void Select(string key, bool withNofity = false)
        {
            foreach (var btn in buttons)
            {
               btn.SetSelected(btn.viewDataKey == key);
            }
            if (withNofity)
                OnSelect?.Invoke(key);
        }

        public void Refresh<T>(IEnumerable<T> datas, System.Func<T, string> funName, System.Func<T, string> funcKey, string selectKey)
        {
            int idx = 0;
            foreach (var v in datas)
            {
                var btn = GetButton(idx);
                btn.viewDataKey = funcKey(v);
                btn.SetLabel(funName(v));
                btn.SetSelected(btn.viewDataKey == selectKey);
                ++idx;
            }
            if (idx < buttons.Count)
            {
                for (int i = idx; i < buttons.Count; ++i)
                {
                    buttons[i].RemoveFromHierarchy();
                }
                buttons.RemoveRange(idx, buttons.Count - idx);
            }
        }

        private Radio GetButton(int index)
        {
            if (index >= buttons.Count)
            {
                Radio button = new Radio();
                button.clicked += () => Select(button.viewDataKey, true);
                button.RegisterCallback<MouseDownEvent>(evt =>
                {
                    if (OnElementMenu != null)
                    {
                        if (evt.button == 1)
                        {
                            GenericMenu menu = new GenericMenu();
                            OnElementMenu(menu, button.viewDataKey);
                            menu.ShowAsContext();
                        }
                    }
                });
                Add(button);
                buttons.Add(button);
                return button;
            }
            return buttons[index];
        }

    }
}
