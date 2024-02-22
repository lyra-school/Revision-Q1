using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Revision_Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Band> bands = new List<Band>();
        private List<string> selection = new List<string>() { "Pop", "Rock", "Indie"};
        private string path = "C:\\test\\";
        private string path2 = "C:\\test\\band.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateBands();
            bandsLbx.ItemsSource = bands;
            genreCbx.ItemsSource = selection;
        }

        private void GenerateBands()
        {
            bands.Add(new IndieBand() { BandName="The Foo Fighters", YearFormed=1994, Members="Dave Grohl, Nate Mendel, Pat Smear, Taylor Hawkins, Chris Shifflett, Rami Jafee"});
            bands.Add(new IndieBand() { BandName="The Rolling Stones", YearFormed=1962, Members="Mick Jagger, Ian Stewart, Dick Taylor, Bill Wyman, Mick Taylor"});
            bands.Add(new PopBand() { BandName="The Beatles", YearFormed=1960, Members="John Lennon, Paul McCartney, George Harrison, Ringo Starr" });
            bands.Add(new RockBand() { BandName="Green Day", YearFormed=1986, Members="Billie Joe Armstrong, Mike Drnt, Tre Cool"});
            bands.Add(new RockBand() { BandName="Arctic Monkeys", YearFormed=2002, Members="Alex Turner, Matt Heldens, Jamie Cook, Nick O'Malley"});
            bands.Add(new PopBand() { BandName="The Strokes", YearFormed=1998, Members="Julian Casablancas, Nick Valensi, Albert Hammond Jr, Nikolai Fraiture, Fabrizio Moretti"});

            bands[0].AddAlbum(new Album(bands[0].YearFormed) { AlbumName = "Test Album 1" });
            bands[1].AddAlbum(new Album(bands[1].YearFormed) { AlbumName = "Test Album 2" });
            bands[2].AddAlbum(new Album(bands[2].YearFormed) { AlbumName = "Test Album 3" });
            bands[3].AddAlbum(new Album(bands[3].YearFormed) { AlbumName = "Test Album 4" });
            bands[4].AddAlbum(new Album(bands[4].YearFormed) { AlbumName = "Test Album 5" });
            bands[5].AddAlbum(new Album(bands[5].YearFormed) { AlbumName = "Test Album 6" });
            bands[0].AddAlbum(new Album(bands[0].YearFormed) { AlbumName = "Test Album 7" });

            bands.Sort();
        }

        private void bandsLbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selectedBand = (Band)bandsLbx.SelectedItem;
            if(selectedBand == null)
            {
                return;
            }
            bandTblk.Text = "Formed: " + selectedBand.YearFormed + "\nMembers: " + selectedBand.Members;

            albumLbx.ItemsSource = selectedBand.Albums;
        }

        private void genreCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = (string)genreCbx.SelectedItem;
            bandsLbx.SelectedItem = null;
            List<Band> display = new List<Band>();
            if(selected == "Pop")
            {
                foreach(Band band in bands)
                {
                    if (band is PopBand)
                    {
                        display.Add(band);
                    }
                }
            } else if(selected == "Rock")
            {
                foreach (Band band in bands)
                {
                    if (band is RockBand)
                    {
                        display.Add(band);
                    }
                }
            } else if(selected == "Indie")
            {
                foreach (Band band in bands)
                {
                    if (band is IndieBand)
                    {
                        display.Add(band);
                    }
                }
            } else
            {
                bandsLbx.ItemsSource = bands;
                return;
            }
            bandsLbx.ItemsSource = display;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Band selectedBand = (Band)bandsLbx.SelectedItem;
                if(selectedBand == null)
                {
                    return;
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                if(!File.Exists(path2))
                {
                    File.Create(path2).Dispose();
                }
                StringBuilder toAppend = new StringBuilder();
                toAppend.Append("\n\n" + selectedBand.ToString() + ", formed: " + selectedBand.YearFormed + ", members: " + selectedBand.Members + "\n\nAlbums: ");
                foreach(Album album in selectedBand.Albums)
                {
                    toAppend.Append("\n" + album.ToString());
                }
                File.AppendAllText(path2, toAppend.ToString());
                bandsLbx.SelectedItem = null;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
