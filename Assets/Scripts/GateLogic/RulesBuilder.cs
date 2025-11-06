using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class RulesBuilder
{
    public static Dictionary<string, Func<string, Func<ICheckable, bool>>> rulesDict = new()
    {
        {"CheckColor", value => (ICheckable check) => check.packageColor == value},
        {"BlockAllButColor", value => (ICheckable check) => check.packageColor != value},
    };
}
