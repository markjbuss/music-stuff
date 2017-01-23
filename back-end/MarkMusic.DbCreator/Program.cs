using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkMusic.Db;
using MarkMusic.OldDb;
using Album = MarkMusic.Db.Album;
using Artist = MarkMusic.Db.Artist;

namespace MarkMusic.DbCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialAlbumNames = new List<string>
            {
                "Another Level",
                "Anywhere But Here",
                "Demo",
                "Greatest Hits",
                "Greatest Hits Disc 1"
            };

            using (var oldDb = new OldDbEntities())
            {

                using (var newDb = new MarkMusicContext())
                {
                    newDb.Database.ExecuteSqlCommand("DELETE FROM ArtistAlbums");
                    newDb.Database.ExecuteSqlCommand("DELETE FROM SongArtists");
                    newDb.Database.ExecuteSqlCommand("DELETE FROM Songs");
                    newDb.Database.ExecuteSqlCommand("DELETE FROM Albums");
                    newDb.Database.ExecuteSqlCommand("DELETE FROM Artists");

                    var processed = 1;
                    var total = oldDb.Mp3s.Count();
                    foreach (var mp3 in oldDb.Mp3s.OrderBy(m => m.Artist).ThenBy(m => m.Album).ThenBy(m => m.TrackNumber))
                    {
                        Console.WriteLine($"{processed} of {total} - Processing MP3 {mp3.Artist} - {mp3.Album} - {mp3.Title}");

                        var artist = newDb.Artists.FirstOrDefault(a => a.Name == mp3.Artist);

                        if (artist == null)
                        {
                            Console.WriteLine($"Creating artist '{mp3.Artist}'");
                            artist = new Artist
                            {
                                Name = mp3.Artist,
                                Albums = new List<Album>(),
                                Songs = new List<Song>()
                            };
                            newDb.Artists.Add(artist);
                        }
                        else
                        {
                            Console.WriteLine($"Artist '{mp3.Artist}' found in New DB");
                        }

                        var song = new Song
                        {
                            Artists = new List<Artist> {artist},
                            Title = mp3.Title,
                            TrackNumber = mp3.TrackNumber > 0 ? mp3.TrackNumber : null
                        };

                        newDb.Songs.Add(song);

                        if (mp3.Album != null)
                        {
                            var album = newDb.Albums.FirstOrDefault(a => a.Name == mp3.Album);

                            if (album == null || (album.Artists.All(a => a != artist) && specialAlbumNames.Contains(album.Name.ToLowerInvariant())))
                            {
                                Console.WriteLine($"Creating album '{mp3.Album}'");
                                album = new Album
                                {
                                    Artists = new List<Artist> {artist},
                                    Name = mp3.Album,
                                    NumberOfTracks = mp3.AlbumTracks > 0 ? mp3.AlbumTracks : null,
                                    Songs = new List<Song> {song}
                                };

                                newDb.Albums.Add(album);
                            }
                            else
                            {
                                Console.WriteLine($"Album '{mp3.Album}' found in New DB");

                                if (album.Artists.All(a => a != artist))
                                {
                                    Console.WriteLine($"New artist '{mp3.Artist}' added to album '{mp3.Album}'");
                                    album.Artists.Add(artist);
                                }

                                album.Songs.Add(song);
                            }
                        }
                        newDb.SaveChanges();

                        processed++;

                        if (processed%100 == 0)
                        {
                            var percentComplete = (int)((double) processed/total*100);
                            Console.WriteLine($"Saving latest changes - {percentComplete} complete");
                        }
                    }
                }
                
            }
        }
    }
}
