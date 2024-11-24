using System.Collections.Generic;

namespace Game
{
    public class ItemFactory : IItemFactoryInterface
    {
        private List<(int id, int cost, TransformData position, string texture)> itemDefinitions;
        
        public ItemFactory()
        {
            itemDefinitions = new List<(int, int, TransformData, string)>
            {
                (0, 2, new TransformData(400, 100), "GameAssets/Assets/item1.png"),
                (1, 2, new TransformData(450, 100), "GameAssets/Assets/item2.png"),
                (2, 2, new TransformData(500, 100), "GameAssets/Assets/item3.png"),
            };
        }

      

        public List<ItemShop> CreateItems()
        {
            var items = new List<ItemShop>();

            foreach (var (id, cost, position, texture) in itemDefinitions)
            {
                ItemShop item = new ItemShop(cost, id);
                item.CreateAsset(position, texture);
                items.Add(item);
            }
            return items;
        }

        public ItemShop CreateItem(int id, int cost,TransformData position, string texture)
        {
            ItemShop itemFromFactory = new ItemShop(cost,id);
            itemFromFactory.CreateAsset(position, texture);
            return itemFromFactory;
        }

        public ItemShop CreateItem(int id)
        {
            var itemDefinition = itemDefinitions.Find(item => item.id == id);
            if (itemDefinition != default)
            {
                return CreateItem(itemDefinition.id, itemDefinition.cost, itemDefinition.position, itemDefinition.texture);
            }
            // Optionally, handle the case when item is not found (e.g., throw an exception or return null)
            return null;
        }

    }
}
