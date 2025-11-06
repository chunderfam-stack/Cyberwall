using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public List<Rule> heldRules = new List<Rule>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public bool blockCheck(ICheckable package)
    {
        foreach (Rule rule in heldRules)
        {
            if (rule.Condition(package)) return true;
        }
        return false;
    }
}
