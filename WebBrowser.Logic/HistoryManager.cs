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

        static Queue<DateTime> MyTime = new Queue<DateTime>();
        static int index;

        public static void AddHistoryItem(HistoryItem item)
        {
            HistoryTableAdapter adapter2 = new HistoryTableAdapter();
            adapter2.Insert(item.URL, item.Title, item.Date);
            MyTime.Enqueue(item.Date);
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
    }
}
