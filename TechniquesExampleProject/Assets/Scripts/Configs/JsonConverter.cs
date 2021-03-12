using UnityEngine;
using Newtonsoft.Json; //Json.Net

public static class JsonConverter
{
    public static BattleConfig LoadBattleConfig()
    {
        // Load the JSON file, tip: don't include .json extension in path
        var textAsset = (TextAsset) Resources.Load("Jsons/MonsterJson");
        var jsonString = textAsset.text;
        return JsonConvert.DeserializeObject<BattleConfig>(jsonString);
    }
}


