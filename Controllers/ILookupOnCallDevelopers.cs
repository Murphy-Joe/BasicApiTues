namespace BasicApi.Controllers
{
    public interface ILookupOnCallDevelopers
    {
        Task<OnCallDeveloperInformation> GetOnCallDeveloperAsync();
    }
}