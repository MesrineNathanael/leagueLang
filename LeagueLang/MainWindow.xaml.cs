using System;

using System.IO;

using System.Windows;

using IWshRuntimeLibrary;
using System.Diagnostics;

namespace LeagueLang
{
    public partial class MainWindow : Window
    {
        string leaguePath;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            if (LeagueExist())
            {
                MessageBox.Show("League detected at : " + leaguePath);
            }
            else
            {
                MessageBox.Show("League was not found, please open your League client for the automatic detection begin and click 'OK'.");
                if (LeagueDetection())
                {
                    MessageBox.Show("League detected at : " + leaguePath);
                }
                else
                {
                    MessageBox.Show("League client was not found.");
                    this.Close();
                }
            }
            label1.Text = "Your League of Legends path is : " + leaguePath;
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("en_US", leaguePath);
        }
        private void Chinese_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("zh_CN", leaguePath);
        }
        private void Japanese_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("ja_JP", leaguePath);
        }
        private void Korean_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("ko_KR", leaguePath);
        }
        private void Vietnamese_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("vn_VN", leaguePath);
        }
        private void French_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("fr_FR", leaguePath);
        }
        private void Spanish_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("es_ES", leaguePath);
        }
        private void German_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("de_DE", leaguePath);
        }
        private void Russian_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("ru_RU", leaguePath);
        }
        private void Italian_Click(object sender, RoutedEventArgs e)
        {
            CheckTest("it_IT", leaguePath);
        }
        private void CheckTest(string locale, string targetPath)
        {
            if (LeagueDetection())
            {
                MessageBox.Show("Please, close your League of Legends Client before.");
            }
            else
            {
                if (chkInk.IsChecked == true)
                {
                    CreateInk(locale, targetPath);
                }
                if (chkLaunch.IsChecked == true)
                {
                    LaunchClient(locale, targetPath);
                }
                MessageBox.Show("Done.");
            }
        }
        private void LaunchClient(string locale, string targetPath)
        {
            var proc = Process.Start(targetPath + "LeagueClient.exe", "--locale=" + locale);
        }
        private void CreateInk(string locale, string targetPath)
        {
            WshShell wsh = new WshShell();
            IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\League of Legends "+ locale +".lnk") as IWshShortcut;
            shortcut.Arguments = "--locale=" + locale;
            shortcut.TargetPath = targetPath + "LeagueClient.exe";
            
            shortcut.WindowStyle = 1;
            shortcut.Description = "League Of Legends shortcut by League language changer";
            shortcut.WorkingDirectory = targetPath;
            shortcut.IconLocation = targetPath + "LeagueClient.exe";
            shortcut.Save();
            
        }
        private bool LeagueExist()
        {
            bool cout=false;
            try
            {
                if (Directory.GetDirectories("C:/Riot Games/League Of Legends/").Length > 0)
                {
                    cout = true;
                    leaguePath = "C:/Riot Games/League Of Legends/";
                }
            }catch (Exception e)
            {

            }

            try
            {
                if (Directory.GetDirectories("C:/Program Files/Riot Games/League Of Legends/").Length > 0)
                {
                    cout = true;
                    leaguePath = "C:/Program Files/Riot Games/League Of Legends/";
                }
            }
            catch (Exception e)
            {

            }  
            
            try
            {
                if (Directory.GetDirectories("D:/Jeux/League Of Legends/").Length > 0)
                {
                    cout = true;
                    leaguePath = "D:/jeux/League Of Legends/";
                }
            }
            catch (Exception e)
            {

            }

            try
            {
                if (Directory.GetDirectories("D:/Games/League Of Legends/").Length > 0)
                {
                    cout = true;
                    leaguePath = "D:/Games/League Of Legends/";
                }
            }
            catch (Exception e)
            {

            }
            return cout;
        }
        private bool LeagueDetection()
        {
            bool cout = false;
            Process[] client = Process.GetProcessesByName("LeagueClientUx");
            if (client.Length > 0)
            {
                cout = true;
                leaguePath = client[0].MainModule.FileName.Remove(client[0].MainModule.FileName.Length - 18);
            }
            else
            {
                cout = false;
            }
            return cout;
        }
    }
}
