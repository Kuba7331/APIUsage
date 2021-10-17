using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RiotSharp;
using RiotSharp.Misc;
using RiotSharp.Http;
using RiotSharp.Endpoints;
using RiotSharp.Interfaces;
using RiotSharp.Caching;

namespace TEST5
{
    
   public class RiotAPI
    {
        static public async void ShowUserData()
        {

            // zdobycie klucza z pliku

            {
            string GetAPIKey(string path)
            {
                StreamReader r = new StreamReader(path);
                return r.ReadToEnd();
            }
            string Key = GetAPIKey("APIKey.txt");

                // zadeklarowanie zmiennej odpowiadajacej za uzycie klucza

            var api = RiotApi.GetInstance(Key, rateLimitPer10s: 100, rateLimitPer10m: 10000);

                // menu

                while (true)
                {
                    Console.WriteLine("Prosze podac nazwe uzytkownika.");

                    //pobranie danych

                    string name = Console.ReadLine();
                    DataClass data = new DataClass();
                    data.setName(name);
                    Console.WriteLine("W jakim regionie, Twoje konto sie znajduje?");
                    Console.WriteLine("Prosze wpisac liczbe, ktora jest obok jednego z ponizszych regionow");
                    Console.WriteLine("1. EUNE");
                    Console.WriteLine("2. EUW");
                    Console.WriteLine("3. NA");

                    // przypisanie pobranych informacji, po czym wypisanie danych pobranych z bazy RIOT GAMES

                    try
                    {
                        int region = Convert.ToInt32(Console.ReadLine());
                        switch (region)
                        {
                            case 1:
                                data.setRegion("eune");
                                RiotSharp.Endpoints.SummonerEndpoint.Summoner summoner = api.Summoner.GetSummonerByNameAsync(Region.Eune, name).Result;
                                Console.WriteLine("Nazwa uzytkownika: " + summoner.Name);
                                Console.WriteLine("Region konta uzytkownika: " + summoner.Region);
                                Console.WriteLine("Poziom uzytkownika: " + summoner.Level);
                                break;
                            case 2:
                                data.setRegion("euw");
                                summoner = api.Summoner.GetSummonerByNameAsync(Region.Euw, name).Result;
                                Console.WriteLine("Nazwa uzytkownika: " + summoner.Name);
                                Console.WriteLine("Region konta uzytkownika: " + summoner.Region);
                                Console.WriteLine("Poziom uzytkownika: " + summoner.Level);
                                break;
                            case 3:
                                data.setRegion("na");
                                summoner = api.Summoner.GetSummonerByNameAsync(Region.Na, name).Result;
                                Console.WriteLine("Nazwa uzytkownika: " + summoner.Name);
                                Console.WriteLine("Region konta uzytkownika: " + summoner.Region);
                                Console.WriteLine("Poziom uzytkownika: " + summoner.Level);
                                break;
                            default:
                                Console.WriteLine("Wystapil blad przy wyborze regionu, prosze sprobowac ponownie!");
                                summoner = null;
                                Console.WriteLine("Prosze nacisnac jakikolwiek przycisk, aby wrocic do poczatku programu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }

                        // Wywolanie drugiego skryptu, ktory wypisuje dane o uzytkowniku o jego MMR'ach (DRUGIE API)

                        MmrAPI.showMMR(data.getName(), data.getRegion());
                    }

                    // Wyjątek ogólny

                    catch (System.AggregateException)
                    {
                        Console.WriteLine("Nazwa uzytkownika zostala blednie podana, lub nie istnieje.");
                        Console.WriteLine("Prosze wpisac nazwe uzytkownika ponownie!");
                        Console.WriteLine("Prosze nacisnac jakikolwiek przycisk");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    // Wyjątek dotyczący problemów z strony API RIOT GAMES

                    catch (RiotSharpException)
                    {
                        Console.WriteLine("Nazwa uzytkownika zostala blednie podana, lub nie istnieje.");
                        Console.WriteLine("Prosze wpisac nazwe uzytkownika ponownie!");
                        Console.WriteLine("Prosze nacisnac jakikolwiek przycisk");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    break;
                }
            }
        }
    }
}
