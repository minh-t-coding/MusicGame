public interface IDataService {

    void SaveData<T>(string relativePath, T data);

    T LoadData<T>(string relativePath);
}
