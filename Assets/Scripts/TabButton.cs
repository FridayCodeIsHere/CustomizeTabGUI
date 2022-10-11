using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action OnSelect;
    public event Action OnDeselect;
    public Image Background { get; private set; }
    public IContent Content => content;
    
    [SerializeField] private  TabGroup tabGroup;
    [SerializeField] private Content content;

    private void Awake()
    {
        Background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    public void Select()
    {
        OnSelect?.Invoke();
    }

    public void Deselect()
    {
        OnDeselect?.Invoke();
    }
}
