using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public delegate void OnMonsterDestroy(Monster monsterToDestroy);
    public static OnMonsterDestroy monsterDestroy;
    
    [SerializeField] private MonsterPool monsterPool;
    private BattleConfig _battleConfig;
    
    //tip: some coding conventions wants an underscore before private variables
    private int _waveMonstersKilled = 0;
    private int _currentWave = 0;
    
    private void Awake()
    {
        _battleConfig = JsonConverter.LoadBattleConfig();

        //lambda expression subscribed to the delegate.
        //I used lambda here even tho the func is a little long for an inline func just to show what a lambda is
        //(lambda = unnamed func here, delegate = "monsterDestroy" which broadcasts events to 'subscribed' functions)
        //tip: another possible func to subscribe to "monsterDestroy" could include a death animation func in an Animation Controller class
        monsterDestroy = (Monster monsterToDestroy) =>
        {
            _waveMonstersKilled++;
            if (_waveMonstersKilled >= _battleConfig.waveConfigs[_currentWave].monsterConfigs.Count) //next wave
            {
                _waveMonstersKilled = 0;
                _currentWave++;
                _currentWave %= _battleConfig.waveConfigs.Count; // TODO: you'd actually stop the battle scene after last wave, or a win screen, etc
            }
            GetNextMonster();
        };
    }

    private void Start()
    {
        GetNextMonster();
    }


    private void GetNextMonster()
    {
        var monster = monsterPool.GetPrefabInstance();
        Sprite sprite = Resources.Load<Sprite>(_battleConfig.waveConfigs[_currentWave].monsterConfigs[_waveMonstersKilled].spriteName);
        //GetComponent is slow! try not to do this on Update unless its infrequent (still faster than Instantiate though)
        monster.GetComponent<SpriteRenderer>().sprite = sprite;
    }

}



