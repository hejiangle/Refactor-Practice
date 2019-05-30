using System.Collections.Generic;
using Kata.Refactor.Before;

namespace UnitTest.FakeDependency
{
    public class FakeSessionServiceForGoldenKey : ISessionService
    {
        public IEnumerable<string> Get<T>(string sessionKey)
        {
            return new List<string> { "GD01TES", "GD02TES", "FAKE" };
        }
    }
}