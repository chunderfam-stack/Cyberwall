using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private Transform[] spawnLocations;
    private string[] colors = new string[4];
    private List<int>[] correctColors = new List<int>[4];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mixColors();
        colors[0] = "red";
        colors[1] = "blue";
        colors[2] = "green";
        colors[3] = "yellow";
        GameObject newGoblin = Instantiate(goblinPrefab, spawnLocations[Random.Range(0, spawnLocations.Length)].position, Quaternion.identity);
        newGoblin.GetComponent<Goblin>().packageColor = "yellow";

        StartCoroutine("spawnGoblins", WaveSystem.instance.waves[WaveSystem.instance.currentWave]);
    }

    void mixColors()
    {
        for(int i = 0; i < 4; i++)
        {
            correctColors[i] = new List<int>();
            for(int b = 0; b < Random.Range(1, 4); b++)
            {
                int newColor = Random.Range(0,4);
                while (correctColors[i].Contains(newColor))
                {
                    newColor = Random.Range(0,4);
                }
                correctColors[i].Add(newColor);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    async void nextWave()
    {
        print(WaveSystem.instance.currentWave);
        WaveSystem.instance.NextWave();
        await Task.Delay(30000);
        if(WaveSystem.instance.gameOver){return;}
        StartCoroutine("spawnGoblins", WaveSystem.instance.waves[WaveSystem.instance.currentWave]);
    }

    void spawnGoblin(GameObject prefab, int spawnSpot)
    {
        int newColor = Random.Range(0, 4);
        int newPosition = spawnSpot;
        GameObject newGoblin = Instantiate(prefab, spawnLocations[newPosition].position, Quaternion.identity);
        ICheckable goblinData = newGoblin.GetComponent<ICheckable>();
        goblinData.packageColor = colors[newColor];
        if(!correctColors[newPosition].Contains(newColor)){goblinData.amGood = true;}
            
    }

    IEnumerator spawnGoblins(WaveObject wave)
    {
        List<GoblinType> goblinTypes = new List<GoblinType>(wave.goblinTypes);
        for(int i = 0; i < goblinTypes.Count; i++)
        {
            goblinTypes[i] = new GoblinType();
            goblinTypes[i].goblin = wave.goblinTypes[i].goblin;
            goblinTypes[i].amount = wave.goblinTypes[i].amount;
        }
        bool breakOut = false;
        for (; ; )
        {
            for(int i = 0; i < 4; i++)
            {
                if(goblinTypes.Count == 0){breakOut = true; break;}
                int pickedGoblin = Random.Range(0, goblinTypes.Count);
                if(goblinTypes[pickedGoblin].amount == 0)
                {
                    goblinTypes.RemoveAt(pickedGoblin);
                    continue;
                }

                spawnGoblin(WaveSystem.instance.findType(goblinTypes[pickedGoblin].goblin), i);
                goblinTypes[pickedGoblin].amount -= 1;
                yield return new WaitForSeconds(wave.timeBetweenSpawns);
            }
            if(breakOut){print("It is done"); break;}
        }
        nextWave();
    }
}
