using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets; // Добавить библиотеку
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithread_TCP_Client
{
	public partial class Form1 : Form
	{
		// Создадим объект TCP клиента 
		static TcpClient clientSocket = new TcpClient();
		// Поток для обмена данными с помощью сокетов 
		NetworkStream serverStream;

		// Вспомогательный метод для вывода сообщения
		public void Display_message (string message)
		{
			richTextBox1.Text = richTextBox1.Text + "\n" + ">>" + message; 
		}

		public Form1 ()
		{
			InitializeComponent();
		}
		
		// Кнопка для установки соединения с сервером 
		private void button1_Click (object sender, EventArgs e)
		{
			string ip_adress = IP_adress.Text;
			string port = Port.Text;

			try
			{
				// Присоединяемся к серверу 
				clientSocket.Connect(ip_adress, Convert.ToInt32(port));
				Status.Text = "Server Connected ...";
				// Получим поток для обмены данными с помощью сокетов 
				serverStream = clientSocket.GetStream(); 
			}
			catch
			{
				// В случае ошибки вывести сообщение
				Status.Text = "Error connecting to server. Try checking IP and port"; 
				MessageBox.Show("Failed to connect");
				return; 
			}
			MessageBox.Show("Connected!");

		}

		private void Send_Click (object sender, EventArgs e)
		{
			// Запустить таймер 
			timer1.Enabled = true;
			// Получить текст сообщения
			string message = Message_from_client.Text;
			Message_from_client.Text = ""; 
			try
			{
				// Получаем байты из строки с сообщением
				byte[] outStream = Encoding.UTF8.GetBytes(message);
				// Записываем в поток 
				serverStream.Write(outStream, 0, outStream.Length);
				// Очищаем данные из потока
				serverStream.Flush();
			}
			catch
			{
				Status.Text = "Error Sending message to server"; 
			}
		}

		// Обработка одного тика таймера
		private void timer1_Tick (object sender, EventArgs e)
		{
			// Каждые несколько милисекунд
			try
			{
				// Если получены новые данные 
				if (clientSocket.Available > 0)
				{
					// То переводим их из байтов в строку и отображаем на экране
					byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
					// Считываем из потока новые данные
					serverStream.Read(inStream, 0, clientSocket.ReceiveBufferSize);
					// Переводим из байтов в символы 
					string returndata = Encoding.UTF8.GetString(inStream);
					if (returndata.Trim('\0') != "")
					{
						Display_message("Data from Server : " + returndata);
					}
					serverStream.Flush();
				}
			}
			catch
			{
				Status.Text = "Error recieving data from server";
			}
		}

		private void Form1_FormClosed (object sender, FormClosedEventArgs e)
		{

			serverStream.Close();
			clientSocket.Close(); 
		}

		private void Form1_FormClosing (object sender, FormClosingEventArgs e)
		{
			serverStream.Close();
			clientSocket.Close();
		}
	}


}
