namespace Movies.Common.Network
{
    using System.Threading.Tasks;

    public interface INetworkService
    {
        Task DeleteAsync(string uri);

        Task<TResult> GetAsync<TResult>(string uri);

        Task<TResult> PostAsync<TResult>(string uri, string jsonData);

        Task<TResult> PutAsync<TResult>(string uri, string jsonData);
    }
}