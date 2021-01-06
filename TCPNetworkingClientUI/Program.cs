using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TCPNetworkingClientUI
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            OtherClient.otherClients.Clear();
            Client.init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ChatUI cUI = new ChatUI(ReadSave());
            cUI.FormClosing += onClose;
            Application.Run(cUI);
        }


        public static void onClose(object sender, FormClosingEventArgs e)
        {
            Client.instance.Disconnect();
            Save(ChatUI.instance.getSave());
        }

        public static void Save(Save s)
        {
            Stream stream = File.Open("InputSave.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, s);
            stream.Close();
        }

        private static Save ReadSave()
        {
            try 
            {
                Stream stream = File.Open("InputSave.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                Save s = (Save) bf.Deserialize(stream);
                stream.Close();
                return s;
            }
            catch
            {
                return new Save();
            }
        }


    }
}
