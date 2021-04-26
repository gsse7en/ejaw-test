public class DataStorage
{
    public DataResponse objectTypes;
    public static DataStorage _instance;
 
    public static DataStorage Instance
    {
        get {
            if (_instance == null) {
                _instance = new DataStorage ();
            }
            return _instance;
        }
    }
 
}