using UnityEngine;

public class Civilian : MonoBehaviour, ICheckable
{
    public string packageColor { get; set; }
    public bool amGood{get;set;}

    public void OnCaught()
    {
        //Test
    }
    
    public void OnAdmit()
    {
        
    }
}
