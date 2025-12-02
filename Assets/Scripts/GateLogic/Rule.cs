using System;
using UnityEngine;

public class Rule
{
    public Func<ICheckable, bool> Condition;
    public int ruleInt;
    public Rule(Func<ICheckable, bool> condition, int myInt)
    {
        Condition = condition;
        ruleInt = myInt;
    }
    public Rule()
    {
        Condition = null;
    }
}
