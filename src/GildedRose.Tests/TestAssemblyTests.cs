using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void NormalItem_Decreases_Quality_Before_Expiration()
        {
            var items = new List<Item>
            {
                new Item { Name = "Normal Item", SellIn = 7, Quality = 23 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(22, items[0].Quality);
            Assert.Equal(6, items[0].SellIn);
        }

        [Fact]
        public void NormalItem_Decreases_Quality_After_Expiration()
        {
            var items = new List<Item>
            {
                new Item { Name = "Normal Item", SellIn = 0, Quality = 17 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(15, items[0].Quality);
        }

        [Fact]
        public void ConjuredItem_Decreases_Quality_Before_Expiration()
        {
            var items = new List<Item>
            {
                new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 19 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(17, items[0].Quality);
        }

        [Fact]
        public void ConjuredItem_Decreases_Quality_After_Expiration()
        {
            var items = new List<Item>
            {
                new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 21 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(17, items[0].Quality);
        }

        [Fact]
        public void AgedBrie_Increases_Quality()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 4, Quality = 12 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(13, items[0].Quality);
        }

        [Fact]
        public void AgedBrie_Increases_Quality_After_Expiration()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 14 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(16, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_Increases_Quality_10_Days_Left()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 18 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(20, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_Increases_Quality_5_Days_Left()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 22 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(25, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_After_Concert()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 35 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_Does_Not_Change()
        {
            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.Equal(80, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);
        }
    }
}