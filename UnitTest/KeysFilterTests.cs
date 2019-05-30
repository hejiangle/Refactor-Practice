using System;
using System.Collections.Generic;
using System.Reflection;
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

            var fakeSessionService = new FakeSessionServiceForGoldenKey();
            
            keysFilter.GetType().GetProperty("SessionService", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(keysFilter, fakeSessionService);
            
            Assert.Throws<ArgumentNullException>(() => keysFilter.Filter(null, true));
        }
        
        [Fact]
        public void ShouldThrowArgumentNullExceptionOnceMarksIsNullAndFilterNonGoldenKeys()
        {
            var keysFilter = new KeysFilter();
            
            var fakeSessionService = new FakeSessionServiceForNonGoldenKey();
            
            keysFilter.GetType().GetProperty("SessionService", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(keysFilter, fakeSessionService);

            Assert.Throws<ArgumentNullException>(() => keysFilter.Filter(null, false));
        }

        [Fact]
        public void ShouldReturnEmptyKeysListWhenMarksAreNotEmpty()
        {
            var keysFilter = new KeysFilter();

            var result = keysFilter.Filter(new List<string> {It.IsAny<string>()}, It.IsAny<bool>());
            
            Assert.Empty(result);
        }

        [Fact]
        public void ShouldReturnEmptyMarksWhenFilterWithEmptyMarks()
        {
            var keysFilter = new KeysFilter();
            var fakeSessionService = new FakeSessionServiceForGoldenKey();
            
            keysFilter.GetType().GetProperty("SessionService", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(keysFilter, fakeSessionService);
            
            var result = keysFilter.Filter(new List<string>(), It.IsAny<bool>());
            
            Assert.Equal(new List<string> (), result);
        }
    }
}