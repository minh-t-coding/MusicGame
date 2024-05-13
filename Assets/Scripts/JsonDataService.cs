using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : IDataService {

    public string SaveData<T>(T data) {
        try {
            return JsonConvert.SerializeObject(data);
        }
        catch(Exception e) {
            Debug.LogError($"Unable to serialize data due to: {e.Message} {e.StackTrace}");
            return "";      
        }
    }

    public T LoadData<T>(string dataString) {
        try {
	        T data = JsonConvert.DeserializeObject<T>(dataString);
            return data;
        }
        catch (Exception e) {
            Debug.LogError($"Unable to load data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }
}
