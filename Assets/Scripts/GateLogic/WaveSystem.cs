using TMPro;
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
        tmPRO.text = (currentWave + 1).ToString() + "/6";
    }

    public GameObject findType(goblinTypes type)
    {
        switch (type)
        {
            case goblinTypes.normal:
                return goblinPrefabs[0];
            case goblinTypes.brute:
                return goblinPrefabs[2];
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
        tmPRO.text = (currentWave + 1).ToString() + "/6";
        if(currentWave > waves.Length - 1){gameOver = true;}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
