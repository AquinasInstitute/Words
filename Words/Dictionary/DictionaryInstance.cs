using Words.Data_Sources;

namespace Words;

public partial class LatinDictionary
{
    private static readonly object InstanceLock = new();
    private static LatinDictionary? _instance;

    private static readonly object DataSourceLock = new();
    private static IDictionaryDataSource? _dataSource;

    /// <summary>
    /// The database connection string used by the canonical data source (which defaults to database).
    /// </summary>
    public static string DatabaseConnectionString = "Server=localhost;Database=test;Uid=naharie;Pwd=induction;";

    /// <summary>
    /// The canonical instance of the dictionary, guaranteed to be loaded in a thread safe manner. 
    /// </summary>
    public static LatinDictionary CanonicalInstance
    {
        get
        {
            if (_instance is not null) return _instance;
            
            lock (InstanceLock)
            {
                _instance ??= new LatinDictionary(new LatinDictionarySettings { SkipUnlikelyInflections = true }, CanonicalDataSource);
            }

            return _instance;
        }
    }
    
    /// <summary>
    /// The canonical instance of the dictionary data source, guaranteed to be loaded in a thread safe manner. 
    /// </summary>
    public static IDictionaryDataSource CanonicalDataSource
    {
        get
        {
            if (_dataSource is not null) return _dataSource;
            
            lock (DataSourceLock)
            {
                _dataSource = new DatabaseDataSource(DatabaseConnectionString);
                // _dataSource = new TextFileDataSource();
            }

            return _dataSource;
        }
    }
}