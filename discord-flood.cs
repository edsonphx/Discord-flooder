using System;
using RestSharp;
using System.Threading;
using System.IO;
using System.Net;

namespace Program
{
    class post
    {
        static void Main()
        {   
            Console.Write("Proxy [On/Off]: ");
            string onOff = Console.ReadLine();
            
            Console.Write("Digite o link de convite do servidor: ");
            string invite = Console.ReadLine();
            invite = invite.Substring(invite.Length - 6);

            Console.Write("Digite o ID do canal: ");
            string ID = Console.ReadLine();

            Console.Write("Digite sua mensagem: ");
            string message = Console.ReadLine();

            string url1 = ("https://discord.com/api/v6/invites/"+invite);
            var client1 = new RestClient(url1);
            client1.Timeout = -1;  

            string url2 = ("https://discord.com/api/v6/channels/"+ID+"/messages");
            var client2 = new RestClient(url2); 
            client2.Timeout = -1; 
            
            string[] tokens = File.ReadAllLines("discord_token.txt");
            int y0 = tokens.Length;

            int time = 500/y0;
            
            int x1 = -1;
            
            joinChannel(tokens, client1);
            
            while(true)
            {   
                x1 = CycleT(x1,y0);
                Thread t1 = new Thread(() => sendMessage(tokens[x1],message ,client2,onOff));
                t1.Start();

                Thread.Sleep(time);

                x1 = CycleT(x1,y0);
                Thread t2 = new Thread(() => sendMessage(tokens[x1],message ,client2,onOff));
                t2.Start();

                Thread.Sleep(time);

                x1 = CycleT(x1,y0);
                Thread t3 = new Thread(() => sendMessage(tokens[x1],message ,client2,onOff));
                t3.Start();

                Thread.Sleep(time);

                x1 = CycleT(x1,y0);
                Thread t4 = new Thread(() => sendMessage(tokens[x1],message ,client2,onOff));
                t4.Start();

                Thread.Sleep(time);
            }
        }

        static void joinChannel(string[] tokenf1, RestClient clientf1)
        {   
            int x0 = -1;
            while(x0 < tokenf1.Length-1)
            {
                x0 = x0 + 1;
                var request1 = new RestRequest(Method.POST);
                request1.AddHeader("Authorization", tokenf1[x0]);
                IRestResponse response1 = clientf1.Execute(request1);
            }
        }
        static void sendMessage(string tokenf2 ,string messagef ,RestClient clientf2,string onOff)
        {   
            if(string.Equals(onOff,"on",StringComparison.OrdinalIgnoreCase) == true)
            {
                proxyOn(clientf2);
            }

            var request2 = new RestRequest(Method.POST);
            request2.AddHeader("Authorization", tokenf2);
            request2.AddHeader("Content-Type", "application/json");
            request2.AddParameter("application/json","{\"content\":\""+messagef+"\"}",  ParameterType.RequestBody);

            IRestResponse response2 = clientf2.Execute(request2);

            string response2STR = response2.Content;
            if(response2STR.Length > 58)
            {
                Console.WriteLine("Sucess.");
            }
            else
            {
               Console.WriteLine("Failed.");
            }
        }

        static void proxyOn(RestClient clientf2)
        {
            Random z = new Random();

            string[] proxys = File.ReadAllLines("proxys.txt");
            clientf2.Proxy = new WebProxy(proxys[z.Next(proxys.Length)]);
        }
        
        static int CycleT(int x1, int y0)
        {
            if(x1 < y0-1)
            {
                x1 = x1+1;
                return x1;
            }
            else
            {
                return 0;
            }
        }
    }
}