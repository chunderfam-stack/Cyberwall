using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;
public class WaveSystem : MonoBehaviour
{
    public enum goblinTypes{normal, brute, worm, fast}
    public GameObject[] goblinPrefabs;
    public static  WaveSystem instance;
    public WaveObject[] waves;
    public int currentWave;
    public bool gameOver;
    public TextMeshProUGUI tmPRO;
    void Awake()
    { 
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        tmPRO.text = (currentWave + 1).ToString() + "/10";
    }

    public GameObject findType(goblinTypes type)
    {
        switch (type)
        {
            case goblinTypes.normal:
                return goblinPrefabs[0];
            case goblinTypes.brute:
                return goblinPrefabs[0];
            case goblinTypes.worm:
                return goblinPrefabs[0];
            case goblinTypes.fast:
                return goblinPrefabs[1];
            default:
                return goblinPrefabs[0];
        }
    }

    public void NextWave()
    {
        currentWave++;
        tmPRO.text = (currentWave + 1).ToString() + "/10";
        if(currentWave > waves.Length - 1){gameOver = true; Debug.Log("BUG INCOMING");}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
