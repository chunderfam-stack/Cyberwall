using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RulesPanel : MonoBehaviour
{
    private Image image;
    [SerializeField] private GameObject Canvas;
    private bool swappedButtons;
    private Gate openedGate = null;
    public static RulesPanel instance;
    private RuleArea[] ruleAreas;
    public GameObject castle;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        image = GetComponent<Image>();
        ruleAreas = RulesContent.instance.getMyRules();
    }

    void Update()
    {
        if (InputSingleton.inputActions.Player.Attack.WasPressedThisFrame())
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Deselect();
            }
            
        }
    }

    void buttonCheck()
    {
        if (swappedButtons) { swappedButtons = false; }
        else{ Deselect(); }
    }

    public void EditGate(Gate gate)
    {
        foreach(Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(true);
        }
        swappedButtons = true;
        image.enabled = true;
        openedGate = gate;
        for(int i = 0; i < gate.heldRules.Count; i++)
        {
            if(gate.heldRules[i].Condition == null)
            {
                ruleAreas[i].SetDisplay();
            }
            else
            {
                ruleAreas[i].SetDisplay(gate.heldRules[i].ruleInt);
            }
        }
    }


    public void AddRule(Vector2Int rule)
    {
        if(openedGate == null) {print("????"); return;}
        switch (rule.x)
        {
            
            case 0:
                openedGate.heldRules[rule.y]= new Rule(RulesBuilder.rulesDict["CheckColor"]("red"), rule.x);
                break;
            case 1:
                openedGate.heldRules[rule.y]= new Rule(RulesBuilder.rulesDict["CheckColor"]("blue"), rule.x);
                break;
            case 2:
                openedGate.heldRules[rule.y]= new Rule(RulesBuilder.rulesDict["CheckColor"]("green"), rule.x);
                break;
            case 3:
                openedGate.heldRules[rule.y]= new Rule(RulesBuilder.rulesDict["CheckColor"]("yellow"), rule.x);
                break;
            default:
                print("????");
                break;
        }
        
    }

    public void RemoveRule(int rule)
    {
        if(openedGate == null) {print("????"); return;}
        openedGate.heldRules[rule] = new Rule();
    }
    
    public void Deselect()
    {
        image.enabled = false;
        foreach(Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
        openedGate = null;
    }
}
