using UnityEngine;
using UnityEngine.UI;

public class HeatSystem : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goblin")
        {
            ICheckable checkable = collision.gameObject.GetComponent<ICheckable>();
            if(!checkable.amGood){slider.value += 1;}
            Destroy(collision.gameObject);
        }
    }
}
