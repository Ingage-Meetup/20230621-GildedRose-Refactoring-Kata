using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality = AdjustQForBrieAndBS(item);
                }
                else
                {
                    item.Quality = AdjustQForStandardItems(item);
                }

                item.SellIn = AdjustSIForStandardItems(item);

                if (item.SellIn < 0)
                {
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        //item.Quality = item.Quality - item.Quality;
                        item.Quality = 0;
                    }
                    else if (item.Name == "Aged Brie")
                    {
                        item.Quality = AdjustQForBrieIfLessThanFifty(item);
                    }
                    else
                    {
                        item.Quality = AdjustQForOtherItems(item);
                    }
                }
            }
        }

        private static int AdjustQForBrieIfLessThanFifty(Item item)
        {
            if (item.Quality < 50)
            {
                return item.Quality + 1;
            }

            return item.Quality;
        }

        private static int AdjustQForOtherItems(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    return item.Quality - 1;
                }
            }
            return item.Quality;
        }

        private static int AdjustSIForStandardItems(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                return item.SellIn - 1;
            }

            return item.SellIn;
        }

        private int AdjustQForStandardItems(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    return item.Quality - 1;
                }
            }

            return item.Quality;
        }

        private static int AdjustQForBrieAndBS(Item item)
        {
            var itemQuality = item.Quality;
            if (itemQuality < 50)
            {
                itemQuality += 1;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (itemQuality < 50)
                        {
                            itemQuality += 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (itemQuality < 50)
                        {
                            itemQuality += 1;
                        }
                    }
                }
            }

            return itemQuality;
        }
    }
}
