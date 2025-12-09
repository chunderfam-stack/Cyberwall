using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoblinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private Transform[] spawnLocations;
    private string[] colors = new string[4];
    private List<int>[] correctColors = new List<int>[4];

    public GameObject instructionPanel;
    public string[] instructions;
    public string[] goading;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI goadingText;

    public GameObject winPanel;

    private bool stoppedSpawning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colors[0] = "red";
        colors[1] = "blue";
        colors[2] = "green";
        colors[3] = "yellow";
        mixColors();

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
         if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();

            // Convert to world space
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));

            // Perform raycast (2D example)
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "Goblin")
                {
                    Goblin checkable = hit.collider.gameObject.GetComponent<Goblin>();
                    checkable.onClick();
                }
            }
        }
        if(stoppedSpawning && transform.childCount == 4)
        {
            stoppedSpawning = false;
            StartCoroutine("NextWaveRoutine");
        } 
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator NextWaveRoutine()
    {
        WaveSystem.instance.NextWave();
        instructionPanel.SetActive(true);
        instructionText.text = instructions[WaveSystem.instance.currentWave];
        goadingText.text = goading[WaveSystem.instance.currentWave];
        Time.timeScale = 0;
        yield return new WaitForSeconds(5f);

        if (WaveSystem.instance.gameOver)
        {
            yield return new WaitForSeconds(5f);
            winPanel.SetActive(true);
            Time.timeScale = 0;
            yield break;
        }
        if(WaveSystem.instance.currentWave != 6)
        {
            mixColors();
        }   
        yield return StartCoroutine(spawnGoblins(
            WaveSystem.instance.waves[WaveSystem.instance.currentWave]
        ));
    }

    public void StartNextWave()
    {
        instructionPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void spawnGoblin(GameObject prefab, int spawnSpot)
    {
        int newColor = Random.Range(0, 4);
        int newPosition = spawnSpot;
        GameObject newGoblin = Instantiate(prefab, spawnLocations[newPosition].position, Quaternion.identity, transform);
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
            if(breakOut){break;}
        }
        stoppedSpawning = true;
    }
}
