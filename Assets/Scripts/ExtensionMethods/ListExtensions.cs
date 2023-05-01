using System.Collections.Generic;
using System.Linq;
using Scriptable;

namespace ExtensionMethods
{
    public static class ListExtensions
    {
        public static IEnumerable<Item> GetAllByItemType(this IEnumerable<Item> list, ItemType type)
        {
            var newList = new List<Item>();
            foreach (var item in list)
                if (item.Type == type)
                    newList.Add(item);
            return newList;
        }

        public static bool TryGetFirstByItemType(this List<Item> list, ItemType type, out Item item)
        {
            item = null;
            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == type)
                {
                    item = list[i];
                    return true;
                }
            }

            return false;
        } 
    }
}