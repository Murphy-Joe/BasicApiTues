using BasicApi.Controllers;

namespace BasicApi.Services
{
    public class LocalDeveloperLookup : ILookupOnCallDevelopers
    {
        public Task<OnCallDeveloperInformation> GetOnCallDeveloperAsync()
        {
            
            return Task.FromResult(new OnCallDeveloperInformation
            {
                OnCallDeveloperEmail = "Bob@aol.com",
                OnCallDeveloperName = "Robert Smith"
            });


        }
    }
}
