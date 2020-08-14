using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.App.Abstract;
using Warehouse.App.Concrete;
using Warehouse.Domain.Entity;

namespace Warehouse.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private IService<Item> _itemService;
        public ItemManager(MenuActionService actionService, IService<Item> itemService)
        {
            _itemService = itemService;
            _actionService = actionService;
        }
        public int AddNewItem()
        {
            var addNewItemMenu = _actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("Please select item type:");
            for (int i = 0; i < addNewItemMenu.Count; i++)
            {
                Console.WriteLine($"{addNewItemMenu[i].Id}. {addNewItemMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            int typeId;
            Int32.TryParse(operation.KeyChar.ToString(), out typeId);
            Console.WriteLine("Please insert name for item:");
            var name = Console.ReadLine();
            var lastId = _itemService.GetLastId();
            Item item = new Item(lastId+1,name, typeId);
            _itemService.AddItem(item);
            return item.Id;
        }

        public void RemoveItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            _itemService.RemoveItem(item);
        }

        public Item GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            return item;
        }

    }
}
