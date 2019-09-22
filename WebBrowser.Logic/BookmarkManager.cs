using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.BookmarksDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class BookmarkManager
    {
        public static void AddBookmarkItem(BookmarkItem item)
        {
            var adapter1 = new BookmarksTableAdapter();
            var rows = adapter1.GetData();


            if (rows.Count == 0)
            {
                adapter1.Insert(item.URL, item.Title);
            }
            else
            {
                List<string> URLs = new List<string>();
                foreach (var row in rows)
                {
                    URLs.Add(row.URL);
                }

                if (!URLs.Contains(item.URL))
                {
                    adapter1.Insert(item.URL, item.Title);
                }
            }
        }

        public static List<BookmarkItem> GetBookmarkItems()
        {
            BookmarksTableAdapter adapter = new BookmarksTableAdapter();
            List<BookmarkItem> results = new List<BookmarkItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                BookmarkItem item = new BookmarkItem();
                item.URL = row.URL;
                item.Title = row.Title;
                item.ID = row.Id;

                results.Add(item);
            }
            return results;
        }

        public static void DeleteBookmarkItem(int id)
        {
            BookmarksTableAdapter adapter = new BookmarksTableAdapter();
            adapter.Delete(id);
        }
    }
}
