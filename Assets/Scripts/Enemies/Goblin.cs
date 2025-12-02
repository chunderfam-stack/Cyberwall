using UnityEngine;

public class Goblin : MonoBehaviour, ICheckable
{
    public string packageColor{ get; set; }
    public bool amGood{get;set;}
    private Vector3 startPos;
    private Vector3 endPos;
    public float speed = 5;

    private Rigidbody2D rb;

    public void OnCaught()
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
    }

    private void FixedUpdate()
    {
        Vector3 direction = endPos - startPos;
        direction.Normalize();
        rb.linearVelocity = direction * speed;
    }

    Sprite DisplayColor()
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
}
