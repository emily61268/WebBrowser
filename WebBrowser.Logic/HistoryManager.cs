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

        static List<DateTime> MyTime = new List<DateTime>();
        static int index;

        public static void AddHistoryItem(HistoryItem item)
        {
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            adapter.Insert(item.URL, item.Title, item.Date);
            MyTime.Add(item.Date);
        }

        public static List<HistoryItem> GetHistoryItems()
        {
            index = 0;
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            List<HistoryItem> results = new List<HistoryItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                HistoryItem item = new HistoryItem();
                item.URL = row.URL;
                item.Title = row.Title;
                item.Date = MyTime.ElementAt(index);

                results.Add(item);

                index++;
            }

            return results;
        }

        public static List<HistoryItem> GetHistoryItems2()
        {
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            List<HistoryItem> results = new List<HistoryItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                HistoryItem item = new HistoryItem();
                item.URL = row.URL;
                item.Title = row.Title;
                item.Date = row.Date;
                item.ID = row.Id;

                results.Add(item);
            }
            return results;
        }

        public static void DeleteHistoryItem(int id, DateTime dateTime, int index)
        {
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            adapter.Delete(id, dateTime);
            MyTime.RemoveAt(index);
        }
    }
}
