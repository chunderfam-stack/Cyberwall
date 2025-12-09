using UnityEngine;

public class GateCollider : MonoBehaviour
{
    [SerializeField] private Gate gate;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goblin")
        {
            ICheckable checkable = collision.gameObject.GetComponent<ICheckable>();
            foreach(Rule rule in gate.heldRules)
            {
                if(rule == null) continue;
                if(rule.Condition == null) continue;
                if(rule.Condition(checkable) == true)
                {
                    checkable.OnCaught();
                    if (checkable.amGood)
                    {
                        HeatSystem.instance.takeHeat();
                    }
                }
            }
        }
    }
}
