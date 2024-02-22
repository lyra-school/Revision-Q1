using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision_Q1
{
    public abstract class Band : IComparable<Band>
    {
        private string _bandName;
        private int _yearFormed;
        private string _members;
        private List<Album> _albums = new List<Album>();

        public string BandName
        {
            get { return _bandName; }
            set { _bandName = value; }
        }
        public int YearFormed
        {
            get { return _yearFormed; }
            set { _yearFormed = value; }
        }
        public string Members
        {
            get { return _members; }
            set { _members = value; }
        }

        public List<Album> Albums
        {
            get { return _albums; }
        }

        public Band()
        {

        }

        public override string ToString()
        {
            return BandName;
        }

        public int CompareTo(Band other)
        {
            return this.BandName.CompareTo(other.BandName);
        }

        public void AddAlbum(Album album)
        {
            _albums.Add(album);
        }
    }
}
