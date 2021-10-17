using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace TEST5
{
    public class MmrAPI
    {

        static public async void showMMR(string name, string region)
        {
            while (true)
            {
                try
                {

                    // Utworzenie klienta przegladarki 

                    var httpClient = HttpClientFactory.Create();
                    var URL = "https://"+ region + ".whatismymmr.com/api/v1/summoner?name="+ name;

                    // Zatrzymanie procesu programu, do momentu otrzymania informacji z bazy danych

                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(URL);

                    // CODE CHECK

                    if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = httpResponseMessage.Content;
                        var data1 = await content.ReadAsAsync<TEST5.Classes.Example>();
                        Console.WriteLine(data1);
                    }

                    // ERROR CODE CHECK

                    else
                    {
                        Console.WriteLine($"Error " + httpResponseMessage.StatusCode);
                    }
                    Console.WriteLine("Prosze nacisnac klawisz escape, aby wyjsc z programu, w innym wypadku, prosze nacisnac jakikolwiek przycisk.");
                }

                // Wyjatek ogolny programu, w wypadku gdyby doszlo do problemu podczas poboru danych.

                catch (System.FormatException)
                {
                    Console.WriteLine("Wystapil blad podczas pobierania danych od uzytkownika, prosimy nastepnym razem uzyc liczbe, a nie litere, prosze sprobowac ponownie!");
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




