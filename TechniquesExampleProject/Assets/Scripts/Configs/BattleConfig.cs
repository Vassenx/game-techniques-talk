using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Be careful, Unity treats serializable non-MonoBehaviour classes like structs.
/// This means do not write BattleData == null, instead try waves == null.
/// tip: use [NonSerialized] for any variables you dont want the json to fill out 
/// </summary>
[System.Serializable]
public class BattleConfig
{
    public List<WaveConfig> waveConfigs;
}

[System.Serializable]
public class WaveConfig
{
    public int id;
    public List<MonsterConfig> monsterConfigs;
}

[System.Serializable]
public class MonsterConfig
{
    public string spriteName;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private string weaponName;
}
