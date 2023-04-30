using System.Collections.Generic;
using Scriptable;

namespace ExtensionMethods
{
    public static class ListExtensions
    {
        public static IEnumerable<Item> GetAllByItemType(this List<Item> list, ItemType type)
        {
            var newList = new List<Item>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == type)
                {
                    newList.Add(list[i]);
                }
            }

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