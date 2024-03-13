using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace VisualElementExtern
{
    public class TableButton : VisualElement
    {
        private readonly List<ToolbarToggle> toolbarToggles = new List<ToolbarToggle>();

        public System.Action<int> OnSelectChange;
        public TableButton()
        {
            style.flexDirection = FlexDirection.Row;
        }

        public void UpdateView(string[] names)
        {
            for (int i=0; i<names.Length; ++i)
            {
                var e = Get(i);
                e.text = names[i];
                e.SetValueWithoutNotify(i==0);
                e.style.display = DisplayStyle.Flex;
            }
            for (int i=names.Length; i<toolbarToggles.Count; ++i)
            {
                toolbarToggles[i].style.display = DisplayStyle.None;
            }
        }

        public void Select(int index)
        {
            if (index < toolbarToggles.Count)
            {
                for(int i = 0; i < toolbarToggles.Count; ++i)
                {
                    toolbarToggles[i].SetValueWithoutNotify(i == index);
                }
            }
        }

        private ToolbarToggle Get(int index)
        {
            if (index < toolbarToggles.Count)
            {
                return toolbarToggles[index];
            }
            ToolbarToggle toolbarToggle = new ToolbarToggle();
            toolbarToggle.RegisterValueChangedCallback((evt) =>
            {
                if (evt.newValue)
                {
                    for (int i = 0; i < toolbarToggles.Count; ++i)
                    {
                        if (i != index)
                        {
                            toolbarToggles[i].SetValueWithoutNotify(false);
                        }
                    }
                    OnSelectChange?.Invoke(index);
                }
                else
                {
                    toolbarToggle.SetValueWithoutNotify(true);
                }
            });
            toolbarToggles.Add(toolbarToggle);
            Add(toolbarToggle);
            return toolbarToggle;
        }
    }
}
