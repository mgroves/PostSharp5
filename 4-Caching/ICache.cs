namespace Caching
{
    public interface ICache
    {
        object this[string key] { get; set; }
    }
}