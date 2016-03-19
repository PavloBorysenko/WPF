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

namespace BorysenkoDatepicer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Zapis {
            public string desc = "";
            public DateTime dateEv;
            public string status = "Актуально";
            public Zapis(string s, DateTime d) {
                desc = s;
                dateEv = d;
            }
        
        }
        List<Zapis> list_event = new List<Zapis>();
        public MainWindow()
        {
            InitializeComponent();
            list_event.Add(new Zapis("событие 1", new DateTime(2016,02,15)));
            list_event.Add(new Zapis("событие 2", new DateTime(2016, 02, 26)));
            list_event.Add(new Zapis("событие 3", new DateTime(2016, 02, 29)));
            list_event.Add(new Zapis("событие 4", new DateTime(2016, 03, 2)));
            select_date.SelectedDate = DateTime.Now.Date;
            complcalend();
            mycalendar.SelectedDate = DateTime.Now.Date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Width == 700)
            {
                this.Width = 400;

                tugle.Content = "Новое>>";
            }
            else
            {
                this.Width = 700;
                tugle.Content = "<<Закрыть";
         
            }
        }
        public void complcalend(){
            try {
                foreach (Zapis item in list_event)
                {
                    mycalendar.SelectedDates.Add(item.dateEv);
                    if (item.dateEv < DateTime.Now.Date)
                    {
                        item.status = "Событие прошло";

                    }
                   

                    //if (item.dateEv < DateTime.Now)
                    //{
                    //    mycalendar.BlackoutDates.Add(new CalendarDateRange(item.dateEv));
                        
                    //}
                    //else {
                    //   mycalendar.SelectedDates.Add(item.dateEv);
                       
                    //}
                    
                    //SelectedDatesCollection c = new SelectedDatesCollection(mycalendar);
                    //c.Add(item.dateEv);


                } 
          
             
            }
            catch (Exception eee) {
                MessageBox.Show(eee.Message);
            }
           
           
        }

        private void mycalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            complcalend();
            var car_date = mycalendar.SelectedDate;
            showdate.Text = car_date.Value.Date.ToShortDateString();
            search_eve();
           
        }
        public void search_eve() {
            var car_date = mycalendar.SelectedDate;
            foreach (var item in list_event) {
                if (car_date.Value.Date == item.dateEv) {
                    desc_text.Text = item.desc;
                    status_eve.Text=item.status;
                    
                    break;
                }
                status_eve.Text = "...";
                desc_text.Text = "Нет событий";
            
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string new_desc = "";
           

            if ((select_date.SelectedDate.Value.Date.ToShortDateString() != "") && (new_eve.Text != ""))
            {
                new_desc = new_eve.Text;
               // MessageBox.Show(select_date.SelectedDate.Value.Date.ToShortDateString());
                DateTime new_date = select_date.SelectedDate.Value.Date;
                list_event.Add(new Zapis(new_desc, new_date));
                new_eve.Text = "";
                select_date.SelectedDate=DateTime.Now.Date;
                complcalend();
                this.Width = 400;
                tugle.Content = "Новое>>";
            }
            else {
                MessageBox.Show("Заполните поля!!!");
            }
        }
    }
}
