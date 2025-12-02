using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public List<Rule> heldRules = new List<Rule>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            heldRules.Add(new Rule());
        }
    }

    public bool blockCheck(ICheckable package)
    {
        foreach (Rule rule in heldRules)
        {
            if (rule.Condition(package)) return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("HAHA!");
    }
}
