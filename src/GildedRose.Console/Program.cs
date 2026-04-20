using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items { get; set; }
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }


        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                if (IsSulfuras(item))
                {
                    continue;
                }

                var hasExpired = item.SellIn <= 0;

                if (IsAgedBrie(item))
                {
                    UpdateAgedBrie(item, hasExpired );
                }
                else if (IsBackstagePass(item))
                {
                    UpdateBackstagePass(item, hasExpired );
                }
                else
                {
                    UpdateNormalItem(item, hasExpired );
                }

                item.SellIn--;
            }
        }

        private void UpdateAgedBrie(Item item, bool hasExpired )
        {
            IncreaseQuality(item);

            if (hasExpired )
            {
                IncreaseQuality(item);
            }
        }

        private void UpdateBackstagePass(Item item, bool hasExpired )
        {
            if (hasExpired )
            {
                item.Quality = 0;
                return;
            }

            IncreaseQuality(item);

            if (item.SellIn <= 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn <= 5)
            {
                IncreaseQuality(item);
            }
        }

        private void UpdateNormalItem(Item item, bool hasExpired )
        {
            // Conjured items degrade twice as fast as normal items
            var degradeAmount = IsConjured(item) ? 2 : 1;

            DecreaseQuality(item, degradeAmount);

            if (hasExpired )
            {
                DecreaseQuality(item, degradeAmount);
            }
        }

        private bool IsConjured(Item item)
        {
            return item.Name.StartsWith("Conjured", System.StringComparison.OrdinalIgnoreCase);
        }
        private bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private bool IsBackstagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private void DecreaseQuality(Item item, int amount = 1)
        {
            item.Quality -= amount;

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }


}
