using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    
    [SerializeField] private List<TabButton> tabButtons;
    
    [SerializeField] private Color _tabIdle;
    [SerializeField] private Color _tabHover;
    [SerializeField] private Color _tabActive;

    private TabButton selectedTab;
    

    private void Start()
    {
        ResetTabs();
    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
            tabButtons = new List<TabButton>();
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.Background.color = _tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
            selectedTab.Deselect();
        
        selectedTab = button;

        selectedTab.Select();
        
        ResetTabs();
        button.Background.color = _tabActive;
        
        HideAllContent();
        button.Content.Show();
        
    }

    public void HideAllContent()
    {
        foreach (TabButton button in tabButtons)
            button.Content.Hide();
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) 
                continue;
            button.Background.color = _tabIdle;
        }
    }
    
}
