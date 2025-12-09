
using UnityEngine;

public class RuleArea : MonoBehaviour
{
    private bool hasDone;
    public void AddRule(int rule)
    {
        if(hasDone == false)
        {
            foreach(Transform child in transform)
            {
                if(child.GetSiblingIndex() == rule) continue;
                child.gameObject.SetActive(false);
            }

            RulesPanel.instance.AddRule(new Vector2Int(rule, transform.GetSiblingIndex()));
            hasDone=true;
        }
        else
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            hasDone=false;
            RulesPanel.instance.RemoveRule(transform.GetSiblingIndex());
        }
    }

    public void SetDisplay()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        hasDone=false;
    }

    public void SetDisplay(int rule)
    {
         foreach(Transform child in transform)
            {
                if(child.GetSiblingIndex() == rule){child.gameObject.SetActive(true); continue;}
                child.gameObject.SetActive(false);
            }
        hasDone = true;
    }
}
