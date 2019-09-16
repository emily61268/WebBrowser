using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.HistoryDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class HistoryManager
    {

        public static void AddHistoryItem(HistoryItem item)
        {
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            adapter.Insert(item.URL, item.Title, item.Date, item.DateTime);
        }

        public static List<HistoryItem> GetHistoryItems()
        {
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            List<HistoryItem> results = new List<HistoryItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                HistoryItem item = new HistoryItem();
                item.ID = row.Id;
                item.URL = row.URL;
                item.Title = row.Title;
                item.Date = row.Date;
                item.DateTime = row.DateTime;

                results.Add(item);
            }
            return results;
        }

        public static void DeleteHistoryItem(int id, DateTime dateTime)
        {
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            adapter.Delete(id, dateTime);
        }
    }
}
