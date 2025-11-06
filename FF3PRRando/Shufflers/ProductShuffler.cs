using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF3PR.Data.Enums;
using FF3PR.Data.Master;
using FF3PRRando.Utility;

namespace FF3PRRando.Shufflers
{
    public class ProductShuffler
    {
        public static List<Product> GetAllProducts(CsvProcessor csvHelper)
        {
            return csvHelper.GetMasterFileContents<Product>("product.csv");
        }

        public static List<Product> ShuffleProducts(List<Product> products, int seedNumber) 
        {
            Random rand = new Random(seedNumber);
            products.Sort((x, y) => x.id.CompareTo(y.id));
            var weaponShops = products.Where(x => Enum.IsDefined(typeof(WeaponShops), x.group_id)).Select(x => x.group_id);
            var armorShops = products.Where(x => Enum.IsDefined(typeof(ArmorShops), x.group_id)).Select(x => x.group_id);
            var itemShops = products.Where(x => Enum.IsDefined(typeof(ItemShops), x.group_id)).Select(x => x.group_id);
            var magicShops = products.Where(x => Enum.IsDefined(typeof(MagicShops), x.group_id)).Select(x => x.group_id);
            var weapons = products.Where(x => Enum.IsDefined(typeof(WeaponShops), x.group_id)).Select(x => x.content_id).ToArray();
            var armor = products.Where(x => Enum.IsDefined(typeof(ArmorShops), x.group_id)).Select(x => x.content_id).ToArray();
            var items = products.Where(x => Enum.IsDefined(typeof(ItemShops), x.group_id)).Select(x => x.content_id).ToArray();
            var magic = products.Where(x => Enum.IsDefined(typeof(MagicShops), x.group_id)).Select(x => x.content_id).ToArray();
            rand.Shuffle(weapons);
            rand.Shuffle(armor);
            rand.Shuffle(items);
            rand.Shuffle(magic);
            var shuffledWeapons = weapons.ToList();
            var shuffledArmor = armor.ToList();
            var shuffledItems = items.ToList();
            var shuffledMagic = magic.ToList();
            for (int i = 0; i < products.Count; i++) 
            {
                if (products[i].content_id == 0)
                    continue;
                switch (products[i].group_id)
                {
                    case int p when weaponShops.Contains(p):
                        if (shuffledWeapons.Count < 1)
                            break;
                        products[i].content_id = shuffledWeapons[0];
                        shuffledWeapons.RemoveAt(0);
                        break;
                    
                    case int p when armorShops.Contains(p):
                        if (shuffledArmor.Count < 1)
                            break;
                        products[i].content_id = shuffledArmor[0];
                        shuffledArmor.RemoveAt(0);
                        break;

                    case int p when itemShops.Contains(p):
                        if (shuffledItems.Count < 1)
                            break;
                        products[i].content_id = shuffledItems[0];
                        shuffledItems.RemoveAt(0);
                        // Make sure Viking's Cove sells Mallets
                        if (products[i].id == 63)
                            products[i].content_id = 9;
                        // Make sure Tozus sells antidotes
                        else if (products[i].group_id == 14)
                            products[i].content_id = 4;
                            break;

                    case int p when magicShops.Contains(p):
                        if (shuffledMagic.Count < 1)
                            break;
                        products[i].content_id = shuffledMagic[0];
                        shuffledMagic.RemoveAt(0);
                        break;
                }
            }
            return products;
        }

        public static void WriteToProductMasterFile(CsvProcessor csvHelper, List<Product> products)
        {
            csvHelper.WriteToMasterFile(products, "product.csv");
        }

    }
}
