﻿using UnityEngine;
using UnityEngine.UI;

public class ItemAdder : MonoBehaviour
{
    // list of prefabs to spawn
    public GameObject[] Items;
    
    // Reference to the Scroll View's 'Content' panel
    public GameObject ScrollViewContentContainer;
    
    // false = use verticalNormalizedPosition, true = use RectTransform.offset
    public Toggle UseRectTransformToggle;
    
    // flip items y scale or not (used by bottom-to-top list)
    public bool NegativeYScale;

    private int m_itemIndex;
    
    public void InsertItemAtHead()
    {
        ScrollRect parentScrollRect = GetComponent<ScrollRect>();
        if (parentScrollRect == null || UseRectTransformToggle == null)
        {
            return;
        }

        m_itemIndex = (m_itemIndex + 1) % Items.Length;

        GameObject newItem = Instantiate(Items[m_itemIndex], ScrollViewContentContainer.transform, false);
        newItem.transform.localScale = new Vector3(1.0f,NegativeYScale ? -1.0f : 1.0f, 1.0f);
        
        if (UseRectTransformToggle.isOn)
        {
            RectTransform xform = xform = ScrollViewContentContainer.GetComponent<RectTransform>();
            if (xform != null)
            {
                if (NegativeYScale)
                {
                    xform.offsetMin -= new Vector2(0.0f, GetItemHeight(newItem) * 2.0f);
                    xform.offsetMax -= new Vector2(0.0f, GetItemHeight(newItem));
                    //xform.offsetMax += new Vector2(0.0f, GetItemHeight(newItem));    
                }
                else
                {
                    xform.offsetMax += new Vector2(0.0f, GetItemHeight(newItem));    
                }
                
            }
        }
        
        // move item to top of hierarchy
        newItem.transform.SetAsFirstSibling();
    }

    public void AddItemAtTail()
    {
        ScrollRect parentScrollRect = GetComponent<ScrollRect>();
        if (parentScrollRect == null || UseRectTransformToggle == null)
        {
            return;
        }
        
        m_itemIndex = (m_itemIndex + 1) % Items.Length;

        GameObject newItem = Instantiate(Items[m_itemIndex], ScrollViewContentContainer.transform, false);
        newItem.transform.localScale = new Vector3(1.0f, NegativeYScale ? -1.0f : 1.0f, 1.0f);

        if (UseRectTransformToggle.isOn)
        {
            RectTransform xform = xform = ScrollViewContentContainer.GetComponent<RectTransform>();
            if (xform != null)
            {
                xform.offsetMin -= new Vector2(0, GetItemHeight(newItem));
            }
        }
        
        // move item to end of hierarchy
        newItem.transform.SetAsLastSibling();
    }
    
    protected float GetItemHeight(GameObject item)
    {
        float itemHeight = 0;
        
        VerticalLayoutGroup layoutGroup = ScrollViewContentContainer.GetComponent<VerticalLayoutGroup>();
        RectTransform itemXform = item.GetComponent<RectTransform>();
        
        if (itemXform != null)
        {
            itemHeight = itemXform.rect.height;
        }

        // add spacing, margin offsets
        if (layoutGroup != null)
        {
            itemHeight += layoutGroup.spacing;
        }
        
        return itemHeight;
    }
}
