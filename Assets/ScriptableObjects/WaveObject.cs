using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Wave")]
public class WaveObject : ScriptableObject
{
    public List<GoblinType> goblinTypes;
    public float timeBetweenSpawns;
}

[Serializable]
public class GoblinType
{
    public WaveSystem.goblinTypes goblin;
    public int amount;
}