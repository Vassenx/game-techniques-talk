using UnityEngine;
using Newtonsoft.Json; //Json.Net

public static class JsonConverter
{
    public static BattleConfig LoadBattleData()
    {
        /* TODO: foreach (var file in Directory.EnumerateFiles("Assets/Jsons", "*.json"))
        {
            using (StreamReader r = new StreamReader(file))
            {   
                string rawJson = r.ReadToEnd();
            }
        }*/

        // Load the JSON file, don't include .json extension in path
        var textAsset = (TextAsset) Resources.Load("Jsons/MonsterJson");
        var jsonString = textAsset.text;
        return JsonConvert.DeserializeObject<BattleConfig>(jsonString);
    }
}


