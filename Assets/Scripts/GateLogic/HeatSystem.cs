using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeatSystem : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public GameObject loseScreen;

    public static HeatSystem instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("heatBarGoDown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeHeat()
    {
        slider.value += 1;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goblin")
        {
            ICheckable checkable = collision.gameObject.GetComponent<ICheckable>();
            if(!checkable.amGood){slider.value += 1;}
            if(slider.value == 15)
            {
                Time.timeScale = 0;
                loseScreen.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
    }

    IEnumerator heatBarGoDown()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(1);
            if(slider.value > 0)
            {
                slider.value -= 0.1f;
            }
        }
    }
}
