using System.Collections.Generic;
using Kata.Refactor.Before;

namespace UnitTest.FakeDependency
{
    public class FakeSessionServiceForNonGoldenKey : ISessionService
    {
        public IEnumerable<string> Get<T>(string sessionKey)
        {
            switch (sessionKey)
            {
                case "SilverKey":
                    return new List<string> {"SV01TES", "SV02TES", "SV03TES"};
                case "CopperKey":
                    return new List<string> {"CP01TES", "CP02TES", "CP03TES"};
                default:
                    return new List<string> {"FAKE"};
            }
        }
    }
}