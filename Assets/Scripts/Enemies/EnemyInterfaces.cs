using UnityEngine;

public interface ICheckable
{
    string packageColor { get; set; }
    bool amGood{get;set;}
    void OnCaught();
    void OnAdmit();
}

public interface IClickable
{
    void OnClick();
}
