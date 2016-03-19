using System;
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
using System.Xml;
using System.Xml.Linq;
namespace BorysenkoWpfExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  
   
  
    public partial class MainWindow : Window
    {
        static int count=0;
        class Vrach
        {
            public int id;
            public string name { get; set; }
            public string spec { get; set; }
            public BitmapImage img { get; set; }
            public double price { get; set; }
            public Vrach(string n, string s, double p,string pa)
            {
                id = count;
                count++;
                name = n;
                spec = s;
                price = p;
                img = new BitmapImage(new Uri("pack://application:,,,/Assets/"+pa));
            }
            public override string ToString()
            {
                return String.Format(this.spec + " - " + this.name);

            }
        }
        class Proff
        {
            public string name;
            public string vred;
            public List<Vrach> vrachi;
            public Proff(string n, string v, List<Vrach> vr)
            {
                name = n;
                vred = v;
                vrachi = vr;
            }
            public Proff(string n, string v)
            {
                name = n;
                vred = v;
                vrachi = new List<Vrach>();
            }
            public override string ToString()
            {
                return String.Format(this.name);

            }
        }
        Vrach v1 = new Vrach("Крапин В.В","Окулист",1200,"v7.jpg");
        Vrach v2 = new Vrach("Лабман Ф.Г", "Пульмонолог", 800, "v2.jpg");
        Vrach v3 = new Vrach("Кротов А.В", "Онколог", 1000, "v3.jpg");
        Vrach v4 = new Vrach("Алсор Н.С", "Инфекционист", 1050, "v4.jpg");
        Vrach v5 = new Vrach("Гильминтов Г.Г", "Невропотолог", 900, "v5.jpg");
        Vrach v6 = new Vrach("Зуранов И.Н", "Психиатр", 870, "v6.jpg");
        Vrach v7 = new Vrach("Бумов З.Б", "Кардиолог", 1150, "v3.jpg");
        Vrach v8 = new Vrach("Ласова Н.А", "Гастроэнтеролог",780, "v1.jpg");
        Vrach v9 = new Vrach("Коршунова Е.А", "Стоматолог", 1200,"v8.jpg");

        //Proff p1 = new Proff("Сварщик", "Вредности1");
        //Proff p2 = new Proff("Учитель", "Вредности2");
        //Proff p3 = new Proff("Агро-летчик", "Вредности3");
        //Proff p4 = new Proff("Сталевар", "Вредности4");
        //Proff p5 = new Proff("Пром-альпенист", "Вредности5");
        //Proff p6 = new Proff("Драгер", "Вредности6");
        //Proff p7 = new Proff("Кузнец", "Вредности7");
        //Proff p8 = new Proff("Отбивщик ртути", "Вредности8");
        //Proff p9 = new Proff("Кислотчик", "Вредности9");
        //Proff p10 = new Proff("Рок-звезда", "Вредности0");
        List<Vrach> general = new List<Vrach>();
        
      

        List<Proff> prof=new List<Proff>();

        public MainWindow()
        {
            InitializeComponent();
            general.Add(v1);
            general.Add(v2);
            general.Add(v3);
            general.Add(v4);
            general.Add(v5);
            general.Add(v6);
            general.Add(v7);
            general.Add(v8);
            general.Add(v9);

           /* //p1.vrachi.Add(v1);
            //p1.vrachi.Add(v2);
            //p1.vrachi.Add(v3);
            //p2.vrachi.Add(v5);
            //p2.vrachi.Add(v6);
            //p2.vrachi.Add(v7);
            //p3.vrachi.Add(v3);
            //p3.vrachi.Add(v6);
            //p4.vrachi.Add(v2);
            //p4.vrachi.Add(v7);
            //p4.vrachi.Add(v1);
            //p5.vrachi.Add(v3);
            //p5.vrachi.Add(v6);
            //p5.vrachi.Add(v5);
            //p6.vrachi.Add(v2);
            //p6.vrachi.Add(v3);
            //p7.vrachi.Add(v2);
            //p7.vrachi.Add(v8);
            //p8.vrachi.Add(v3);
            //p8.vrachi.Add(v2);
            //p8.vrachi.Add(v8);
            //p9.vrachi.Add(v5);
            //p9.vrachi.Add(v7);
            //p9.vrachi.Add(v2);
            //p9.vrachi.Add(v9);

            //p10.vrachi.Add(v1);
            //p10.vrachi.Add(v2);
            //p10.vrachi.Add(v3);
            //p10.vrachi.Add(v4); 
            //p10.vrachi.Add(v5);

            //p10.vrachi.Add(v6);
            //p10.vrachi.Add(v7);
            //p10.vrachi.Add(v8);
            //prof.Add(p1);
            //prof.Add(p2);
            //prof.Add(p3);
            //prof.Add(p4);
            //prof.Add(p5);
            //prof.Add(p6); 
            //prof.Add(p7);
            //prof.Add(p8);
            //prof.Add(p9);
            //prof.Add(p10); */
            get_data();
            let_start();
             
           
           // update();
        }

        private void listprof_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
              
                if (listprof.SelectedIndex != -1)
                {
                    textskidka.Text = "0";
                    textsumaSkidka.Text = "0";
                    // listprof.ItemsSource = prof;
                    //myList.Items.Clear();
                    var t = (Proff)listprof.SelectedItem;
                    //MessageBox.Show(t.vrachi.Count.ToString());
                   
                    myList.ItemsSource = t.vrachi;
                    textVrednost.Text = t.vred;
                    suma_uslug.Text = Suma_uslugi(t).ToString();
                }
                else
                {
                   
                   // myList.Items.Clear();
                    textVrednost.Text = "";
                    suma_uslug.Text = "";
                }

            }
            catch (Exception eee) {
                MessageBox.Show(eee.Message);
            }
            
           
        }
        double Suma_uslugi(Proff vere) {
            double sum = 0;
            foreach (Vrach p in vere.vrachi)
            {
                sum += p.price;
            }
            return sum;
        }
     
        public void update() {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"../../proff.xml");
            XmlElement xR = xDoc.DocumentElement;

            xR.RemoveAll();

            xDoc.Save(@"../../proff.xml");
            foreach (Proff item in prof) {
                try
                {
                    XmlDocument X = new XmlDocument();
                    X.Load(@"../../proff.xml");


                    XmlElement xRoot = X.DocumentElement;
                    XmlElement proffElem = X.CreateElement("proff");
                    XmlElement nameElem = X.CreateElement("name");
                    XmlElement vredElem = X.CreateElement("vred");
                    XmlElement vrachiElem = X.CreateElement("vrachi");
                   

                    XmlText nameText = X.CreateTextNode(item.name);
                    XmlText vredText = X.CreateTextNode(item.vred);
                    foreach (Vrach it in item.vrachi) {
                        XmlElement vrachElem = X.CreateElement("vrach");
                        XmlText temp = X.CreateTextNode(it.id.ToString());
                        vrachElem.AppendChild(temp);
                        vrachiElem.AppendChild(vrachElem); 
                    }

                    vredElem.AppendChild(vredText);
                    nameElem.AppendChild(nameText);
                    proffElem.AppendChild(nameElem);
                    proffElem.AppendChild(vredElem);
                    proffElem.AppendChild(vrachiElem);

                    xRoot.AppendChild(proffElem);


                    X.Save(@"../../proff.xml");

                }
                catch (Exception eee) {

                    MessageBox.Show(eee.Message);
                }
            
            }
        
        
        
        }

        public void get_data() {
            prof = new List<Proff>();
            XmlDocument xDoc = new XmlDocument();
            var path = Environment.CurrentDirectory;
            try {

                xDoc.Load(@"../../proff.xml");

                XmlElement xRoot = xDoc.DocumentElement;

                foreach (XmlNode node in xRoot)
                {
                    string name = "";
                    string vred = "";

                    List<Vrach> tenpvrachi = new List<Vrach>();
                    if (node.Name == "proff") {
                        foreach (XmlNode proffNode in node.ChildNodes)
                        {
                            if (proffNode.Name == "name") {
                                name = proffNode.InnerText;
                            }
                            if (proffNode.Name == "vred")
                            {
                                vred = proffNode.InnerText;
                            }

                            if (proffNode.Name == "vrachi")
                            {
                                foreach (XmlNode vrachiNode in proffNode.ChildNodes) {
                                    if (vrachiNode.Name == "vrach") {
                                        int ind = int.Parse(vrachiNode.InnerText);
                                        
                                        foreach (Vrach item in general)
                                        {
                                            if (item.id == ind)
                                            {
                                                tenpvrachi.Add(item);
                                            }
                                        }
                                    }
                                }
                            }
                        }



                    }

                    prof.Add(new Proff(name,vred,tenpvrachi));
                }

            }
            catch (Exception eee) {
                MessageBox.Show(eee.Message); 
                }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (this.Width == 550)
            {
                this.Width = 800;
                editProff(false);

            }
            else {
                this.Width = 550;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 550;
            editname.Text = "";
            editvred.Text = "";
            listvrach.SelectedIndex = -1;
        }
        public void editProff(bool b) {
            listvrach.ItemsSource = general;
            listproff2.SelectedIndex = -1;
            if (b) {
                listproff2.ItemsSource = prof;
                listproff2.Visibility = Visibility.Visible;
                

            } else {
                listproff2.Visibility=Visibility.Hidden;
                editname.Text = "";
                editvred.Text = "";
            }
        
        
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.Width == 550)
            {
                this.Width = 800;
                editProff(true);

            }
            else
            {
                this.Width = 550;
            }
        }

        private void listproff2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listproff2.SelectedIndex != -1) {
                    var tempEdit = (Proff)listproff2.SelectedItem;
                    listvrach.SelectedIndex = -1;
                    editname.Text = tempEdit.name;
                    editvred.Text = tempEdit.vred;
                    for (int i = 0; i < general.Count; i++)
                    {
                        var t = (Vrach)listvrach.Items[i];
                        foreach (Vrach item in tempEdit.vrachi)
                        {
                            if (t.id == item.id)
                            {
                                listvrach.SelectedItems.Add(listvrach.Items[i]);

                            }
                        }
                    }
                }
                
            }
            catch (Exception eee) {
                MessageBox.Show(eee.Message);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Vrach> temp=new List<Vrach>();
            if (editname.Text != "" && editvred.Text != "")
            {
                var d = listvrach.SelectedItems;

                foreach (Vrach tr in d)
                {
                    temp.Add(tr);
                }

                if (listproff2.SelectedIndex == -1)
                {

                    prof.Add(new Proff(editname.Text, editvred.Text, temp));
                    //MessageBox.Show("ok");
                }
                else
                {
                    int indx = listproff2.SelectedIndex;
                    prof[indx].name = editname.Text;
                    prof[indx].vred = editvred.Text;
                    prof[indx].vrachi = temp;

                }
                update();
               // MessageBox.Show("ok1");
                editname.Text = "";
                editvred.Text = "";
               // MessageBox.Show("ok2");
                listvrach.SelectedIndex = -1;
               // listprof.SelectedIndex = -1;
               // MessageBox.Show("ok3");
                listprof.ItemsSource =new List<Proff>();
               // MessageBox.Show("ok4");
                get_data();
                let_start();
                this.Width = 550;
            }
            else {
                MessageBox.Show("Заполните поля");
            }
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (listproff2.SelectedIndex != -1) {
                int indx = listproff2.SelectedIndex;
              
                prof.RemoveAt(indx);
                update();
                editname.Text = "";
                editvred.Text = "";
                listvrach.SelectedIndex = -1;
               
                get_data();
                listprof.ItemsSource = prof;
                
                this.Width = 550;
            
            }
        }
        public void let_start() {
            listprof.ItemsSource = prof;
        }

        private void textskidka_SelectionChanged(object sender, RoutedEventArgs e)
        {
            double s;
            if (textskidka.Text == "")
            {
                s = 0;
            }
            else { 
            s = double.Parse(textskidka.Text);
            }
             
            double u = double.Parse(suma_uslug.Text);
            textsumaSkidka.Text = ((1 - (s / 100)) * u).ToString();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Gray);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.White);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Khaki);
        }
    }
}
