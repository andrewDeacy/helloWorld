namespace HelloWorld.Database
{
    public interface IDatabaseConnectionSettings
    {
        IDatabaseConnectionSetting ConnectionString1 { get; }
        IDatabaseConnectionSetting ConnectionString2 { get; }
    }
}