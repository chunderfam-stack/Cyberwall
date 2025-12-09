using UnityEngine;
using UnityEngine.Rendering;

public class Goblin : MonoBehaviour, ICheckable
{
    public string packageColor{ get; set; }
    public bool amGood{get;set;}
    protected Vector3 startPos;
    protected Vector3 endPos;
    public float speed = 5;

    protected Rigidbody2D rb;

    public virtual void OnCaught()
    {
        Destroy(this.gameObject);
    }
    
    public void OnAdmit()
    {
        
    }

    private void Awake()
    {
        startPos = transform.position;
        endPos = new Vector3(0,1.5f * (3-Mathf.FloorToInt(speed)),0);
        rb = GetComponent<Rigidbody2D>();
        Invoke("figureItOut", 0.1f);
    }

    public Goblin(int newSpeed)
    {
        speed = newSpeed;
    }

    void figureItOut()
    {
        SpriteRenderer goblinImage = GetComponent<SpriteRenderer>();
        goblinImage.sprite = DisplayColor();
        if (!amGood)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = endPos - startPos;
        direction.Normalize();
        rb.linearVelocity = direction * speed;
    }

    protected Sprite DisplayColor()
    {

        switch (packageColor)
        {
            case "red":
                return GoblinSpriteManager.Instance.goblinSprites[0];
            case "blue":
                return GoblinSpriteManager.Instance.goblinSprites[1];
            case "green":
                return GoblinSpriteManager.Instance.goblinSprites[2];
            case "yellow":
                return GoblinSpriteManager.Instance.goblinSprites[3];
            default:
                Debug.Log("No Color");
                return GoblinSpriteManager.Instance.goblinSprites[2];
        }
    }


    void waitDestroy()
    {
        Destroy(this.gameObject);
    }

    public void onClick()
    {
        if (amGood)
        {
            HeatSystem.instance.takeHeat();
        }
        Destroy(this.gameObject);
    }

}
