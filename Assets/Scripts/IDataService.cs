public interface IDataService {

    string SaveData<T>(T data);

    T LoadData<T>(string dataString);
}
