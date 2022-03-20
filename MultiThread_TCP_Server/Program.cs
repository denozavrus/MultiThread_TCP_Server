using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Необходимые библиотеки для сокетов и многопоточности
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace MultiThread_TCP_Server
{
    public class Client
    {
        // Поле с TCP клиентом
        private TcpClient clientSocket;
        // ID клиента
        static int ID = 1;
        public int Id {get; private set;}
        // Создадим конструктор для класса Client
        public Client (TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            this.Id = ID;
            ID ++;
        }

        private void Exchange_Message ()
        {
            // Количество запросов от клиента 
            int requestCount = 0;
            while (true)
            {
                // Возвращает поток для отправки и приема сообщений 
                try
                {
                    // Если есть новые данные в сокете от клиента 
                    if (clientSocket.Available > 0)
                    {
                        // Создаем новый поток 
                        NetworkStream networkStream = clientSocket.GetStream();
                        // Считывает данные из потока в массив
                        byte[] ClientBytes = new byte[clientSocket.ReceiveBufferSize];
                        networkStream.Read(ClientBytes, 0, clientSocket.ReceiveBufferSize);
                        // Переводим данные в строку 
                        string dataFromClient = Encoding.UTF8.GetString(ClientBytes).Trim('\0');
                        // Выведем полученное сообщение
                        Console.WriteLine(" >> " + "From client-" + this.Id + ": " + dataFromClient);
                        // Номер запроса 
                        requestCount = requestCount + 1;
                        string rCount = Convert.ToString(requestCount);
                        // Создаем ответ сервера 
                        string serverResponse = "Server to client(" + this.Id + "), request number: " + rCount + "\n" + dataFromClient;
                        // Переводим в байты 
                        var ServerBytes = Encoding.UTF8.GetBytes(serverResponse);
                        // Отправим байты по сокету 
                        networkStream.Write(ServerBytes, 0, ServerBytes.Length);
                        // Удаляем данные из потока 
                        networkStream.Flush();
                        Console.WriteLine(" >> " + serverResponse);
                    } 
                }
                catch (InvalidOperationException)
                {
                    // В случае ошибки закрыть клиент 
                    clientSocket.Close();                    
                    return; 
                }
                catch (Exception ex)
                {
                    // В случае любых других ошибок вывести сообщение ошибки
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        // Метод, запускающий обмен сообщениями (Exchange_Message) в потоке
        public void Start()
        {
            Thread clientThread = new Thread(Exchange_Message);
            clientThread.Start();
        }
    }
        class Program
	{
		static void Main (string[] args)
		{

			const string ip = "127.0.0.1"; // Статичный айпи адрес сервера
			const int port = 8080; // Выбор порта 

			// Передаем в класс, отвечающий за конечный порт IP адрес и порт
			var TcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            // Сокет на сервере
			TcpListener server_socket = new TcpListener(TcpEndPoint);

            // Клиентский сокет
			TcpClient client_socket = new TcpClient();

            server_socket.Start(); 

			while (true)
			{
                // Принимает запрос на подключение
                client_socket = server_socket.AcceptTcpClient();
                // Создадим экземпляр клиента
                Client client = new Client(client_socket);
                Console.WriteLine(" >> " + "Client ID:" + Convert.ToString(client.Id.ToString()) + " started!");
                // Запускаем поток клиента 
                client.Start();
			}
		}
	}
}