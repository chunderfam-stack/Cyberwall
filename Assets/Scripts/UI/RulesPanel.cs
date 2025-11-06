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
    // Start is called once 
    // image.rectTransform.localPosition = new Vector3(trbefore the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
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
        image.rectTransform.localPosition = Vector3.zero;
        transform.SetParent(Canvas.transform);
        Vector3 localPos = image.rectTransform.localPosition;
        localPos.x *= 2f;
        localPos.y *= 2f;
        image.rectTransform.localPosition = localPos;
    }
    
    public void Deselect()
    {
        image.enabled = false;
        foreach(Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
    }
}
