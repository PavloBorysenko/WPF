using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;


namespace BorysenkoAsyncCountText
{
    public class rezult {
        public int cGL{get;set;}
        public int cSO { get; set; }
         public string name { get; set; }

         public TimeSpan speed { get; set; }
        public override string ToString()
        {
            return String.Format(this.name+"  Гласных:"+this.cGL+"   Согласных:"+this.cSO+"  Время:"+this.speed);

        }
    }
    
    public class Folder
    {
        private DirectoryInfo _folder;
        private ObservableCollection<Folder> _subFolders;
       private ObservableCollection<FileInfo> _files;

        public Folder()
        {
            this.FullPath = @"d:\";
        }

        public string Name
        {
            get
            {
                return this._folder.Name;
            }
        }

        public string FullPath
        {
            get
            {
                return this._folder.FullName;
            }

            set
            {
                if (Directory.Exists(value))
                {
                    this._folder = new DirectoryInfo(value);
                }
                else
                {
                    throw new ArgumentException("must exist", "fullPath");
                }
            }
        }

        public ObservableCollection<FileInfo> Files
        {
            get
            {
                if (this._files == null)
                {
                    this._files = new ObservableCollection<FileInfo>();

                    FileInfo[] fi = this._folder.GetFiles();

                    for (int i = 0; i < fi.Length; i++)
                    {
                        this._files.Add(fi[i]);
                    }
                }

                return this._files;
            }
        }

        public ObservableCollection<Folder> SubFolders
        {
            get
            {
                if (this._subFolders == null)
                {
                    this._subFolders = new ObservableCollection<Folder>();

                    DirectoryInfo[] di = this._folder.GetDirectories();

                    for (int i = 0; i < di.Length; i++)
                    {
                        Folder newFolder = new Folder();
                        newFolder.FullPath = di[i].FullName;
                        this._subFolders.Add(newFolder);
                    }
                }

                return this._subFolders;
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static object workerLocker = new object();
        static int runningWorkers = 0;
        static Stopwatch GenstopWatch = new Stopwatch();
        List<FileInfo> files_list;
        List<rezult> rez;
        int countGL = 0;
        int countSO = 0;
        public MainWindow()
        {
            InitializeComponent();
           // TreeViewItem tem = treeView1.Items;
            
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            int count = 0;
            files_list = new List<FileInfo>();
            var temp=listView2.Items;
            foreach (FileInfo i in temp) {
               // MessageBox.Show(i.Extension);
                if (i.Extension.ToString() == ".txt") { 
                count++;
                files_list.Add(i);
                }
            
            }
            counttext.Content = count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listView2.Items.Count <= 0) { MessageBox.Show("sdfghj"); }
            GenstopWatch.Reset();
            if (files_list.Count <= 0  )
            {
                MessageBox.Show("Нет ни одного текстового файла");

            }
            else
            {
                GenstopWatch.Start();
                runningWorkers = files_list.Count;
                reztex.Items.Clear();
              foreach (FileInfo item in files_list) {

                  CountChar(item);
               }
             // MessageBox.Show(countGL + "   " + countSO);
              //TimeSpan ts = new TimeSpan();
              //foreach (rezult t in reztex.Items)
              //{

              //    ts = ts.Add(t.speed);
              //}
              //totaltimeText.Content = ts;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try {

                WaitCallback workingItem = new WaitCallback(PrintTheNumers);
                //Stopwatch stopWatch = new Stopwatch();
                GenstopWatch.Reset();

                if (files_list.Count <= 0 || listView2.Items.Count<=0)
                {
                    MessageBox.Show("Нет ни одного текстового файла");

                }
                else
                {
                    GenstopWatch.Start();
                    //stopWatch.Start();
                    runningWorkers = files_list.Count;
                    reztex.Items.Clear();
                    foreach (FileInfo item in files_list)
                    {

                        System.Threading.ThreadPool.QueueUserWorkItem(workingItem, item);
                    }
                    // MessageBox.Show(countGL+"   "+countSO);

                    //lock (workerLocker)
                    //    while (runningWorkers > 0)
                    //        Monitor.Wait(workerLocker);
                 

                  
                    //TimeSpan ts = new TimeSpan();
                    //stopWatch.Stop();
                    //ts = stopWatch.Elapsed;

                    //totaltimeText.Content = ts;
                }
            
            }
            catch (Exception eee) {
                MessageBox.Show(eee.Message);
               
            }
           
           
        }

        public void CountChar(FileInfo f) {
            try {

                
                countGL = 0;
                countSO = 0;


                rezult temprez = new rezult();
                temprez.name = f.Name;
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();


                using (StreamReader sr = f.OpenText())
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {

                        foreach (char ch in s)
                        {
                            //MessageBox.Show(ch.ToString());
                            if (ch == 'а' || ch == 'о' || ch == 'е' || ch == 'у' || ch == 'й' || ch == 'ы' || ch == 'э' || ch == 'я' || ch == 'и' || ch == 'ю')
                            {
                                countGL++;
                            }
                            else if (ch != '.' || ch != ',' || ch != ' ' || ch != '-' || ch != '!' || ch != '?' || ch != ':' || ch != ';')
                            {
                                countSO++;
                            }
                        }
                    }
                }
                temprez.cGL = countGL;
                temprez.cSO = countSO;
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                
                temprez.speed = stopWatch.Elapsed;
                runningWorkers--;
                if (runningWorkers <= 0)
                {
                    GenstopWatch.Stop();
                    totaltimeText.Dispatcher.Invoke(new Action(delegate()
                    {
                        totaltimeText.Content = GenstopWatch.Elapsed;
                    }));
                    //stop();
                    //  MessageBox.Show("ok");
                }
                reztex.Dispatcher.Invoke(new Action(delegate()
                {
                    reztex.Items.Add(temprez);
                }));

               
                //lock (workerLocker)
                //{
                //    runningWorkers--;
                //    Monitor.Pulse(workerLocker);
                //}
                //   // reztex.Items.Add(temprez);
            
                
                
            }
            catch (Exception eee) {
                MessageBox.Show(eee.Message);
            }


            
        }

        public void stop() {
            totaltimeText.Content = "stop";
        }
        public void PrintTheNumers(object state)
        { 

            FileInfo f1 = (FileInfo)state;
            CountChar(f1);
        }
    }
}