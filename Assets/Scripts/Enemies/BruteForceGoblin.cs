using System.Collections.Generic;
using UnityEngine;

public class BruteForceGoblin : Goblin
{
    private int bounces = 1;
    private List<string> colors;
    public BruteForceGoblin(int newSpeed) : base(newSpeed)
    {
        speed = newSpeed;
        bounces = 1;
    }

    public override void OnCaught()
    {
        colors =  new List<string>()
        {
        "yellow",
        "red",
        "blue",
        "green"
        };
        bounces--;
        if(bounces == -2){Destroy(this.gameObject);}
        Vector3 direction = endPos - startPos;
        direction.Normalize();
        transform.position -= direction * 3;
        int newColor = Random.Range(0, 4);
        base.packageColor = colors[newColor];
        SpriteRenderer goblinImage = GetComponent<SpriteRenderer>();
        goblinImage.sprite = DisplayColor();
        
    }
}
