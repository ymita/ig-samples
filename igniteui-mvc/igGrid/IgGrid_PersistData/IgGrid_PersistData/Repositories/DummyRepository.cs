using IgGrid_PersistData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgGrid_PersistData.Repositories
{
    public static class DummyRepository
    {
        //ダミーデータ
        private static List<Item> Items
            = new List<Item>{
                new Item() { Id = 1, FirstName = "Edward", LastName = "Funderburk" },
                new Item() { Id = 2, FirstName = "Nina", LastName = "Hunter" },
                new Item() { Id = 3, FirstName = "Ramona", LastName = "Iverson" },
                new Item() { Id = 4, FirstName = "Chong", LastName = "Stimson" },
                new Item() { Id = 5, FirstName = "Bethany", LastName = "Carey" },
            };

        /// <summary>
        /// Item コレクションをリターンする
        /// </summary>
        /// <returns>Item コレクション</returns>
        public static List<Item> getItems()
        {
            return Items;
        }

        /// <summary>
        /// Item オブジェクトを更新する
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="colName"></param>
        /// <param name="value"></param>
        /// <returns>更新結果</returns>
        public static bool updateItem(int rowId, string colName, string value)
        {
            Item itemToUpdate = Items.Where(x => x.Id == rowId).First();
            itemToUpdate.GetType().GetProperty(colName).SetValue(itemToUpdate, value);

            return true;
        }
    }
}