using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision_Q1
{
    public class Album
    {
        private string _albumName;
        private DateTime _released;
        private int _sales;

        private static Random rnd = new Random();

        public string AlbumName
        {
            get { return _albumName; }
            set { _albumName = value; }
        }
        public DateTime Released
        {
            get { return _released; }
        }
        public int Sales
        {
            get { return _sales; }
        }

        public Album(int yearFormed)
        {
            _released = new DateTime(rnd.Next(yearFormed, 2024), 1, 1);
            _sales = rnd.Next(3000000);
        }

        public override string ToString()
        {
            return AlbumName + ", Released: " + Released.Day + "-" + Released.Month + "-" + Released.Year + ", Sold: " + Sales + ", Years since release: " + (DateTime.Now.Year - Released.Year);
        }
    }
}
