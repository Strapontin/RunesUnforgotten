using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        LeagueClient leagueClient = new LeagueClient();
        const string ENDPOINT_SESSION = @"/lol-champ-select/v1/session";
        bool doScan = false;
        CancellationTokenSource cancellationToken;

        bool restart = false;

        public Form1()
        {
            InitializeComponent();
            leagueClient.Init();

            cancellationToken = new CancellationTokenSource();
            StartScan();
            Scan();
        }

        public void StartScan()
        {
            cancellationToken.Cancel();
            doScan = true;
            ImgState.BackColor = Color.Green;
        }

        private void StopScan()
        {
            cancellationToken.Cancel();
            doScan = false;
            ImgState.BackColor = Color.Red;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private async void Scan()
        {
            if (!doScan)
                return;

            textBox1.Text = DateTime.Now.ToString();

            try
            {
                string json = await leagueClient.test(ENDPOINT_SESSION);
                //string json = System.IO.File.ReadAllText(@"E:\Anthony\Devs\Lol\GlassLCU-master\WindowsFormsApp1\Data\temp.txt");

                Session session = JsonConvert.DeserializeObject<Session>(json);

                textBox1.Text += $"\r\nactions != null {session.actions != null}";

                if (session.actions != null)
                {
                    bool done = session.actions.SelectMany(action => action).All(action => action.completed);

                    textBox1.Text += $"\r\ndone = {done}";

                    if (done)
                    {
                        // Shows windows on front
                        new Thread(() =>
                        {
                            var processes = ProcessResolver.GetProcessesByName("Blitz").Append(ProcessResolver.GetProcessesByName("LeagueClientUx")[0]);
                            processes = processes.Where(process => process.MainWindowHandle.ToInt32() != 0);

                            foreach (var process in processes)
                            {
                                SetForegroundWindow(process.MainWindowHandle);
                            }

                            MessageBox.Show("Pick tes runes", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }).Start();

                        StopScan();

                        cancellationToken = new CancellationTokenSource();
                        await Task.Delay(70 * 1000).ContinueWith((task) => { cancellationToken.Token.ThrowIfCancellationRequested(); StartScan(); }, cancellationToken.Token);
                    }
                }
            }
            catch (Exception ex)
            {
                leagueClient = new LeagueClient();
                leagueClient.Init();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartScan();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopScan();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Scan();
        }
    }
}
