using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> addressBook = new Dictionary<string, string>();

        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        SimpleTcpServer server;
        SimpleTcpClient client1;

       
        private void Form1_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            
            addressBook.Add("Kika", "127.0.0.2:9000");
            addressBook.Add("Srecko", "127.0.0.3:9000");
            addressBook.Add("Mika", "127.0.0.4:9000");

           

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text) && lstClientIp.SelectedItem != null)
                {
                    client1.Connect();
                    client1.Send(txtIP.Text + ": " + Coding(txtMessage.Text));

                   
                    txtInfo.Text += $"Me: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIP.Text) && addressBook.ContainsKey(txtIP.Text))
            {
                txtIP.Enabled=false;
                server = new SimpleTcpServer(addressBook[txtIP.Text]);
                server.Events.ClientConnected += Events_ClientConnected;
                server.Events.ClientDisconnected += Events_ClientDisconnected;
                server.Events.DataReceived += Events_DataReceived;
                server.Start();
                txtInfo.Text += $"Starting...{Environment.NewLine}";
                btnStart.Enabled = false;
                btnSend.Enabled = true;
                var filteredKeys = addressBook.Where(pair => pair.Key != (txtIP.Text)).Select(pair => pair.Key);

                lstClientIp.Items.AddRange(filteredKeys.ToArray());


            }


        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                
                string[] data = (Encoding.UTF8.GetString(e.Data)).Split(' ');
                txtInfo.Text += $"{data[0]}: {Decoding(data[1])}{Environment.NewLine}";

                if (radioButton1.Checked == true)
                {
                    txtInfo.Text += $"{data[0]}: {(data[1])}{Environment.NewLine}";
                    radioButton1.Checked = false;
                }
                //Kod korisnika koji prima poruke treba da bude cekiran paralelni prikaz pre primanja poruke




            });
        }

        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort}disconnected.{Environment.NewLine}";
                lstClientIp.Items.Remove(e.IpPort);
            });

        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //txtInfo.Text += $"{e.IpPort}connected.{Environment.NewLine}";
                //lstClientIp.Items.Add(e.IpPort);

            });

        }
      
        private string Coding(string tekst)
        {
            tekst = tekst.ToLower().Replace("j", "i").Replace(" ", "");
            string alphabet = "phqgmeaylnofdxkrcvszwbuti";
            int[] nizI = new int[tekst.Length];
            int[] nizJ = new int[tekst.Length];
            int count = 0;
            char[,] matrix = new char[5, 5];
            char[] code = new char[tekst.Length];
            int[] script = new int[2 * tekst.Length];
            bool found = false;
            int i, j;
            int ostatak = tekst.Length % 5;
            int brojac = tekst.Length / 5;


            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    matrix[i, j] = alphabet[i * 5 + j];
                }
            }

            //prolazak kroz tekst
            while (tekst.Length > count)
            {

                found = false;
                i = 0;
                while (i < 5 && found == false)
                {
                    j = 0;
                    while (j < 5 && found == false)
                    {
                        if (tekst[count] == matrix[i, j])
                        {
                            nizI[count] = i;
                            nizJ[count] = j;
                            found = true;
                        }
                        j++;
                    }
                    i++;
                }



                count++;
            }
            //kreiranje finalnog niza brojeva
            for (i = 0; i < brojac; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    script[i * 10 + j] = nizI[i * 5 + j];
                    script[i * 10 + j + 5] = nizJ[i * 5 + j];

                }
            }
            for (i = 0; i < ostatak; i++)
            {
                script[brojac * 10 + i] = nizI[brojac * 5 + i];
                script[brojac * 10 + i + ostatak] = nizJ[brojac * 5 + i];

            }
            count = 0;
            //kodiranje
            for (i = 0; i < tekst.Length; i++)
            {

                code[i] = matrix[script[count], script[++count]];
                count++;
            }

            return new string(code);
        }

        private string Decoding(string code)
        {
            int count = 0, i, j, pom;
            bool found = false;
            code = code.ToLower().Replace("j", "i").Replace(" ", "");//preventivno
            string alphabet = "phqgmeaylnofdxkrcvszwbuti";
            int[] nizI = new int[code.Length];
            int[] nizJ = new int[code.Length];
            char[,] matrix = new char[5, 5];
            int[] script = new int[2 * code.Length];
            int ostatak = code.Length % 5;
            int brojac = code.Length / 5;
            char[] tekst = new char[code.Length];

            //kreiranje matrice azbuke
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    matrix[i, j] = alphabet[i * 5 + j];
                }
            }

            //pronalazenje vrednosti iz matrice
            while (code.Length > count)
            {

                found = false;
                i = 0;
                while (i < 5 && found == false)
                {
                    j = 0;
                    while (j < 5 && found == false)
                    {
                        if (code[count] == matrix[i, j])
                        {
                            pom = count * 2;
                            script[pom] = i;
                            script[pom + 1] = j;
                            found = true;
                        }
                        j++;
                    }
                    i++;
                }
                count++;
            }

            //delimo niz script u delove od po 10
            for (i = 0; i < brojac; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    nizI[i * 5 + j] = script[i * 10 + j];
                    nizJ[i * 5 + j] = script[i * 10 + j + 5];

                }
            }
            for (i = 0; i < ostatak; i++)
            {
                nizI[brojac * 5 + i] = script[brojac * 10 + i];
                nizJ[brojac * 5 + i] = script[brojac * 10 + i + ostatak];

            }
            //kodiranje
            for (i = 0; i < code.Length; i++)
            {

                tekst[i] = matrix[nizI[i], nizJ[i]];

            }
            return new string(tekst);
            //return code;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            //radioButton1.Checked = !radioButton1.Checked;
            
        }

        private void lstClientIp_SelectedIndexChanged(object sender, EventArgs e)
        {
            client1 = new SimpleTcpClient(addressBook[lstClientIp.SelectedItem.ToString()]);
        }
    }
}