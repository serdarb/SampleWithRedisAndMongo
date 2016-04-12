using Xunit;

using Project.Business.Managers;

namespace Project.Business.Test
{
    public class CacheManagerTests
    {
        [Fact]
        public void should_add_item_to_cache()
        {
            var key = "key";
            var value = "value";

            var result = CacheManager.AddOrUpdateItem(key, value);

            Assert.True(result);
        }

        [Fact]
        public void should_get_item_from_cache_by_key()
        {
            var key = "key";
            var value = "value";

            CacheManager.AddOrUpdateItem(key, value);

            var result = CacheManager.GetItem(key);

            Assert.Equal(result, (string)value);
        }

        [Fact]
        public void should_clear_all_cache()
        {
            var result = CacheManager.Clear();

            Assert.True(result);
        }

    }
}