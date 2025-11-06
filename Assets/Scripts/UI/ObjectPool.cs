using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject templateRule;
    [SerializeField] private Transform addButton;
    private Stack<GameObject> unusedObjects = new Stack<GameObject>();
    public static ObjectPool instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else{ Destroy(this); }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newRule = Instantiate(templateRule, templateRule.transform.position, templateRule.transform.rotation, templateRule.transform.parent);
            newRule.transform.SetSiblingIndex(1);
            newRule.SetActive(false);
            unusedObjects.Push(newRule);


        }
        
    }
    

    public GameObject grabRule()
    {
        if (unusedObjects.Count > 0)
        {
            GameObject grabbedRule = unusedObjects.Pop();
            grabbedRule.transform.SetSiblingIndex(addButton.GetSiblingIndex() - 1);
            return grabbedRule;
        }
        GameObject newRule = Instantiate(templateRule, templateRule.transform.position, templateRule.transform.rotation, templateRule.transform.parent);
        newRule.transform.SetSiblingIndex(addButton.GetSiblingIndex());
        unusedObjects.Push(newRule);
        return unusedObjects.Pop();
    }
}
