using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class InpectorElement : VisualElement
{

    private IMGUIContainer top = new IMGUIContainer();
    private Foldout foldout = new Foldout();
    private Toggle toggle = new Toggle();
    private Label label = new Label();
    private VisualElement bottom;
    public override VisualElement contentContainer => bottom;
    public System.Action<GenericMenu> OnContextMenue;
    public string Text
    {
        get
        {
            return label.text;
        }
        set
        {
            label.text = value;
        }
    }

    public InpectorElement()
    {
        foldout.style.top = 2;
        toggle.style.top = 2;
        label.style.top = 3;
        top.RegisterCallback<MouseDownEvent>(evt =>
        {
            foldout.value = !foldout.value;
            evt.StopPropagation();
        });
        top.Add(foldout);
        top.Add(toggle);
        top.Add(label);
        top.style.flexDirection = FlexDirection.Row;
        top.onGUIHandler = OnGUIHandle;
        top.style.height = 20;
        hierarchy.Add(top);
        var containter = new VisualElement();
        containter.style.top = 20;
        hierarchy.Add(containter);
        bottom = containter;
        foldout.RegisterValueChangedCallback(evt =>
        {
            bottom.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
            evt.StopPropagation();
        });
    }

    public VisualElement AddHeaderElement(VisualElement element)
    {
        top.Add(element);
        return element;
    }

    private void OnGUIHandle()
    {
        GUILayout.Box("", "IN Title");
        if (OnContextMenue != null)
        {
            Rect rect = GUILayoutUtility.GetLastRect();
            rect.x = rect.width - 20;
            rect.width = 20;
            rect.y += 2;
            rect.height -= 2;
            if (GUI.Button(rect, "", "PaneOptions"))
            {
                GenericMenu genericMenu = new GenericMenu();
                OnContextMenue(genericMenu);
                if (genericMenu.GetItemCount() > 0)
                {
                    genericMenu.ShowAsContext();
                }
            }
        }
    }
}
