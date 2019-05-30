using System;
using System.Collections.Generic;
using System.Reflection;
using Kata.Refactor.After;
using Kata.Refactor.Before;
using Moq;
using UnitTest.FakeDependency;
using Xunit;

namespace UnitTest
{
    public class KeysFilterTests
    {
        [Fact]
        public void ShouldThrowArgumentNullExceptionOnceMarksIsNullAndFilterGoldenKeys()
        {
            var keysFilter = new KeysFilter();
            var newKeysFilter = new NewKeysFilter();

            var fakeSessionService = new FakeSessionServiceForGoldenKey();
            
            keysFilter.GetType().GetProperty("SessionService", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(keysFilter, fakeSessionService);
            
            Assert.Throws<ArgumentNullException>(() => keysFilter.Filter(null, true));
            Assert.Throws<ArgumentNullException>(() => newKeysFilter.Filter(null));
        }
        
        [Fact]
        public void ShouldThrowArgumentNullExceptionOnceMarksIsNullAndFilterNonGoldenKeys()
        {
            var keysFilter = new KeysFilter();
            var newKeysFilter = new NewKeysFilter();
            
            var fakeSessionService = new FakeSessionServiceForNonGoldenKey();
            
            keysFilter.GetType().GetProperty("SessionService", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(keysFilter, fakeSessionService);

            Assert.Throws<ArgumentNullException>(() => keysFilter.Filter(null, false));
            Assert.Throws<ArgumentNullException>(() => newKeysFilter.Filter(null));
        }

        [Fact]
        public void ShouldReturnEmptyKeysListWhenMarksAreNotEmpty()
        {
            var keysFilter = new KeysFilter();
            var newKeysFilter = new NewKeysFilter();

            var result = keysFilter.Filter(new List<string> {It.IsAny<string>()}, It.IsAny<bool>());
            var newResult = newKeysFilter.Filter(new List<string> {It.IsAny<string>()});
            
            Assert.Empty(result);
            Assert.Empty(newResult);
        }

        [Fact]
        public void ShouldReturnEmptyMarksWhenFilterWithEmptyMarks()
        {
            var keysFilter = new KeysFilter();
            var fakeSessionService = new FakeSessionServiceForGoldenKey();
            
            var newKeysFilter = new NewKeysFilter();
            
            keysFilter.GetType().GetProperty("SessionService", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(keysFilter, fakeSessionService);
            
            var result = keysFilter.Filter(new List<string>(), It.IsAny<bool>());
            var newResult = newKeysFilter.Filter(new List<string>());
            
            Assert.Empty(result);
            Assert.Empty(newResult);
        }
    }
}