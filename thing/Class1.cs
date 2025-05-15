using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace thing
{
    class Class1
    {
        string[,] songAndArtist = new string[100, 3];


        public void AddSongAndArtist()
        {
            Console.Clear();
            Console.WriteLine("======== Add Song ========");
            Console.Write("Enter the song title: ");
            string songName = Console.ReadLine();
            Console.Write("Enter the artist: ");
            string songArtist = Console.ReadLine();
            Console.Write("Enter genre: ");
            string songGenre = Console.ReadLine();

            

            for (int i = 0; i < songAndArtist.GetLength(0); i++)
            {
                if (string.IsNullOrEmpty(songAndArtist[i, 0]))
                {
                    songAndArtist[i, 0] = songName;
                    songAndArtist[i, 1] = songArtist;
                    songAndArtist[i, 2] = songGenre;

                    break;
                }

            }
            /* for (int j = 0; j < songAndArtist.GetLength(0); j++)
             {
                 if (string.IsNullOrEmpty(songAndArtist[j, 1]))
                 {
                     songAndArtist[j, 1] = songArtist;
                     break;
                 }
             }
             for (int k = 0; k < songAndArtist.GetLength(0); k++)
             {
                 if (string.IsNullOrEmpty(songAndArtist[k, 2]))
                 {
                     songAndArtist[k, 2] = songGenre;
                     break;
                 }
             }*/
            Console.Clear();
            Console.WriteLine("================");
            Console.WriteLine("Song added successfully!");
            
            
        }

        public void viewAll()
        {
            Console.Clear();
            Console.WriteLine("======== View Playlist ========");
            Console.Write("Do you want to view the whole list?[1], the artist [2], or the genre [3]? ");
            int viewOpt = int.Parse(Console.ReadLine());
            if (viewOpt == 1)
            {
                Console.WriteLine("\n===== All Songs =====\n");
                for (int i = 0; i < songAndArtist.GetLength(0); i++)
                {
                    if (!string.IsNullOrEmpty(songAndArtist[i, 0]))
                    {
                        Console.WriteLine($"{songAndArtist[i, 0]} -- {songAndArtist[i, 1]} || Genre: {songAndArtist[i, 2]}");
                    }

                }
                Console.WriteLine("\n================");
                
            }
            else if (viewOpt == 2)
            {
                Console.Write("Who is the artist you want to search for? ");
                string artistName = Console.ReadLine();

                Console.WriteLine($"\n======== Songs by {artistName} ========\n");
                for (int i = 0; i < songAndArtist.GetLength(0); i++)
                {
                    if (songAndArtist[i, 1] == artistName)
                    {
                        Console.WriteLine($"{songAndArtist[i, 0]}");
                        
                    }
                    
                }
                
                Console.WriteLine("\n================");
            }
            else if (viewOpt == 3)
            {
                Console.Write("What is the genre you want to search? ");
                string genre = Console.ReadLine();

                Console.WriteLine($"======== Songs that are {genre}: ======== \n");
                for (int i = 0; i < songAndArtist.GetLength(0); i++)
                {
                    if (songAndArtist[i, 2] == genre)
                    {
                        Console.WriteLine($"{songAndArtist[i, 0]}");
                    }
                }
                
                Console.WriteLine("\n================");
            }
        }

        public void update()
        {
            Console.Clear();
            Console.Write("What song do you want to edit? [Input the song title]: ");
            string songToBeEdited = Console.ReadLine();
            Console.Write("Who is the artist of the song? [Input song artist]: ");
            string artistOfSong = Console.ReadLine();

            for (int i = 0; i < songAndArtist.GetLength(0); i++)
                if (songAndArtist[i, 0].ToLower() == songToBeEdited.ToLower() && songAndArtist[i, 1].ToLower() == artistOfSong.ToLower())
                {
                    while (true)
                    {
                        Console.Write("What do you want to edit? [1 for title, 2 for artist, 3 for genre] ");
                        int editOpt = int.Parse(Console.ReadLine());
                        if (editOpt == 1)
                        {
                            Console.Write("Enter new song title: ");
                            string newSongTitle = Console.ReadLine();

                            songAndArtist[i, 0] = newSongTitle;
                            Console.Write("Title changed successfully!");
                            Console.Clear();
                            Console.WriteLine("================");
                            break;
                        }
                        else if (editOpt == 2)
                        {
                            Console.Write("Enter new artist name: ");
                            string newArtistName = Console.ReadLine();

                            songAndArtist[i, 1] = newArtistName;
                            Console.Write("Artist name changed successfully!");
                            Console.Clear();
                            Console.WriteLine("================");
                            break;
                        }
                        else if (editOpt == 3)
                        {
                            Console.Write("Enter new song genre: ");
                            string newSongGenre = Console.ReadLine();

                            songAndArtist[i, 2] = newSongGenre;
                            Console.Write("Genre changed successfully!");
                            Console.Clear();
                            Console.WriteLine("================");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Cannot be found...");
                    break;
                }
        }
        public void deleteSong()
        {
            Console.Write("What song do you want to delete? [Input the song title]: ");
            string songToBeEdited = Console.ReadLine();
            Console.Write("Who is the artist of the song? [Input song artist]: ");
            string artistOfSong = Console.ReadLine();
            Boolean found = false;
            for (int i = 0; i < songAndArtist.GetLength(0); i++)
            {
                if (songAndArtist[i, 0].ToLower() == songToBeEdited.ToLower() && songAndArtist[i, 1].ToLower() == artistOfSong.ToLower())
                {
                    found = true;
                    if (!string.IsNullOrEmpty(songAndArtist[i, 0]))
                    {
                        songAndArtist[i, 0] = songAndArtist[i + 1, 0];
                        songAndArtist[i, 1] = songAndArtist[i + 1, 1];
                        songAndArtist[i, 2] = songAndArtist[i + 1, 2];

                        songAndArtist[i, 0] = null;
                        songAndArtist[i, 1] = null;
                        songAndArtist[i, 2] = null;
                        Console.WriteLine("Song deleted successfully");
                        Console.Clear();
                        Console.WriteLine("================");
                    }

                    break;
                }

            }

            if (!found)
            {
                Console.WriteLine("Cannot be found...");
                Console.Clear();
                Console.WriteLine("================");

            }
        }
        class Mainthing
        {

            public static void Main(String[] args)
            {
                Class1 methods = new Class1();

                while (true)
                {
                    Console.WriteLine("=============== Music List ===============");
                    Console.Write("[1] - Add Song to List \n" +
                    "[2] - View Songs in List \n" +
                    "[3] - Update Song List \n" +
                    "[4] - Delete Song in List \n" +
                    "[0] - Exit \n\n>> ");

                    int option = int.Parse(Console.ReadLine());



                    if (option == 1)
                    {
                        methods.AddSongAndArtist();

                    }
                    else if (option == 2)
                    {
                        methods.viewAll();
                    }
                    else if (option == 3)
                    {
                        methods.update();
                    }
                    else if (option == 4)
                    {
                        methods.deleteSong();
                    }
                    else if (option == 0)
                    {
                        Console.WriteLine("Exiting application...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please enter a valid option.");

                    }
                    
                    


                }
            }
        }
    }
}
