using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private MonsterPool monsterPool;
    
    void Awake()
    {
        var battleData = JsonConverter.LoadBattleData();
        Sprite sprite = Resources.Load<Sprite>(battleData.waveConfigs[1].monsterConfigs[1].spriteName);

        var monster = monsterPool.GetPrefabInstance();
        
        monster.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
