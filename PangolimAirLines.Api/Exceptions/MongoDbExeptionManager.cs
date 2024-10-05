namespace PangolimAirLines.Api.Exceptions;
using MongoDB.Driver;
public static class MongoDbExeptionManager
{
    public static void HandleException(Exception ex)
    {
        // Handle specific exceptions
        switch (ex)
        {
            case MongoWriteException  mongoWriteException:
                HandleMongoWriteException(mongoWriteException);
                break;
            case MongoWriteConcernException mongoWriteConcernException:
                HandleMongoWriteConcernException(mongoWriteConcernException);
                break;
            case MongoConnectionException mongoConnectionException:
                HandleMongoConnectionException(mongoConnectionException);
                break;
            default:
                HandleGeneralException(ex);
                break;
        }
    }

    private static void HandleMongoWriteException(MongoWriteException ex)
    {
        Console.WriteLine($"{ex.Message}");
    }

    private static void HandleMongoWriteConcernException(MongoWriteConcernException ex)
    {
        //this method is handling the MongoDuplicateKeyException too
        Console.WriteLine($"{ex.Message}");
    }
    
    private static void HandleMongoConnectionException(MongoConnectionException ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
    

    private static void HandleGeneralException(Exception ex)
    {
        Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
    }
}

