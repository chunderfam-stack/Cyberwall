using UnityEngine;
using TMPro;
using System.Linq;

public class ColorSwatchDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    // Colors you want in the dropdown
    private readonly Color[] colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.magenta,
        Color.cyan,
        Color.white,
        Color.black
    };

    public enum ColorValues{Red,Green,Blue,Yellow,Magenta,Cyan,White,Black}

    void Start()
    {
        dropdown.ClearOptions();

        for(int i = 0; i < colors.Count(); i++)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(
                ((ColorValues)i).ToString(),      // label
                CreateSwatchSprite(colors[i]),  // icon
                colors[i]
            ));
        }

        dropdown.onValueChanged.AddListener(OnSelected);
    }

    // Create a small colored square as a sprite
    private Sprite CreateSwatchSprite(Color color)
    {
        int size = 32;

        Texture2D tex = new Texture2D(size, size);
        var pixels = new Color[size * size];

        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = color;

        tex.SetPixels(pixels);
        tex.Apply();

        // Turn texture into sprite
        return Sprite.Create(tex, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f));
    }

    private void OnSelected(int index)
    {
        Color selected = colors[index];
        Debug.Log("Selected color: " + selected);
    }
}