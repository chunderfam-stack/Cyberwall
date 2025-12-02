using UnityEngine;

public class RulesContent : MonoBehaviour
{
    public static RulesContent instance;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public RuleArea[] getMyRules()
    {
        return GetComponentsInChildren<RuleArea>();
    }
}
