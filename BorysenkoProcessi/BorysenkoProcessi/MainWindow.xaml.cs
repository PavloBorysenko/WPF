using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

using System.Collections.ObjectModel;
// System.Runtime.Remoting.Messaging;

namespace BorysenkoProcessi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
  
    
    public partial class MainWindow : Window
    {
       
        public ObservableCollection<Process> temp;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            temp = new ObservableCollection<Process>();
         
            listProc.ItemsSource = temp;
           

            timer.Tick += new EventHandler(Get_All_Proc);
            timer.Interval = new TimeSpan(0, 0, 2);
           
        }


       
        public void Get_All_Proc(object sender, EventArgs e)
        {
            try { 
               // MessageBox.Show("ok");        
            Process[] localAll = Process.GetProcesses();
           
            textcount.Text = "Количеcтво процессов: " + localAll.Count<Process>();
     
         
            temp.Clear();
            foreach (var item in localAll)
            {
                //string s = "";
                //s += "Имя:  " + item.ProcessName + "    ID: " + item.Id + "    Кол-во потоков: " + item.Threads.Count + "   Число дискрипторов " + item.HandleCount;
                //listProc.Items.Add(s);
               
                temp.Add(item);
                
            
                }
           
            }
            catch (Exception eee) {
                MessageBox.Show(eee.Message);
            }
           
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            timer.Start();
            //Get_All_Proc();
            //Timer tmr = new Timer(test, "", 500, 100);
           
            //for (int i=0;i<3 ;i++ )
            //{
            //    Get_All_Proc();
            //    Thread.Sleep(5000);
            //}
                
              // binOp.Invoke();
               //for (; ; )
               //{
               //    Get_All_Proc();
               //    Thread.Sleep(5000);
               //}
          

     

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try {
                int x = listProc.Items.Count;
                string[] listpr = new string[x];
                int i = 0;
                //var t = (Process)listProc.SelectedItem;

                foreach (Process item in listProc.Items)
                {

                    listpr[i++] = "Имя:  " + item.ProcessName + "    ID: " + item.Id + "    Кол-во потоков: " + item.Threads.Count + "   Число дискрипторов " + item.HandleCount;
                }
                WriteTextAsync(listpr);
            }
            catch (Exception eee) { MessageBox.Show(eee.Message); }
               
        }
        static async void WriteTextAsync(string [] text)
        {
            try {
            // Set a variable to the My Documents path.
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            // Write the text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(@"\ProcessText.txt"))
            {
                foreach (string s in text) { 
                 await outputFile.WriteLineAsync(s);
                }
               
            }
            MessageBox.Show(@"Все процессы были записаны в D\ProcessText.txt");
            }
            catch (Exception eee) { MessageBox.Show(eee.Message); }
        }
        //public static void ShowProcess()
        //{
        //    ManagementObjectSearcher searcher =
        //    new ManagementObjectSearcher("root\\CIMV2",
        //       "Select Name, CommandLine From Win32_Process");

        //    foreach (ManagementObject instance in searcher.Get())
        //    {
        //        for(int i=0;i<instance.)
        //            instance["childId"];
        //        //Console.WriteLine("{0}", instance["Name"]);
        //    }
            
        //}
    }
}
