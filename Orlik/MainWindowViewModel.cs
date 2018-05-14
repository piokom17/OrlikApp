using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Orlik
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            GetOrlikList();
            //bylo sprawdzane na sztywno czy sie binduje dobrze do matchingItems kolekcji
            //MatchingItems.Add(new ORLIK_DATABASE1 { Name = " xd", Adress = "Grojecka" });
            //MatchingItems.Add(new ORLIK_DATABASE1 { Name = " aa", Adress = "Kazimierzowsska" });

            //canExecute(this.selectedItem);
            
        }

        private ObservableCollection<ORLIK_DATABASE1> _matchingItems = new ObservableCollection<ORLIK_DATABASE1>();
        public ObservableCollection<ORLIK_DATABASE1> MatchingItems
        {

            get
            {
                return _matchingItems;
            }
            set
            {
                _matchingItems = value;
                OnPropertyChanged("MatchingItems");
                
            }
        }

        private ORLIK_DATABASE1 _selectedItem;

        public ORLIK_DATABASE1 selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("seletedItem");
            }
        }


        private ORLIK_DATABASE1 _selectedOrlikItem;
        public ORLIK_DATABASE1 selectedOrlikItem
        {
            get { return _selectedOrlikItem; }
            set
            {
                _selectedOrlikItem = value;
                OnPropertyChanged("selectedOrlikItem");
            }
        }

        private CodeFirstDemoEntities context = new CodeFirstDemoEntities();

        private ICommand _command;

        public ICommand Command
        {
            get
            {
                return _command ?? (_command = new RelayCommand(
               x =>
               {
                   _matchingItems.Clear();
                   GetMatchingOrlikList();
                   OnPropertyChanged("command");
               }));
            }
            
        }
        private ICommand _bookCommand;

        public ICommand bookCommand
        {
            get
            {
                return _bookCommand ?? (_bookCommand = new RelayCommand(
               x =>
               {
                   
                   GetBookedPitch();
                   OnPropertyChanged("bookCommand");
                   selectedOrlikItem = null;
                   
               }));
            }
        }

        public void GetBookedPitch()
        {
            try
            {
                MessageBox.Show($"Wybrano {selectedOrlikItem.Name} w godzinach: {selectedOrlikItem.Open_Hour.ToShortTimeString()} : {selectedOrlikItem.Close_Hour.ToShortTimeString()}");
            }
            catch(Exception ex)
            {
                if (selectedOrlikItem == null)
                    MessageBox.Show("You didn't select the pitch. Please selected prefered pitch}");
            }
        }

        public void GetMatchingOrlikList()
        {
            
            foreach (var item in orlikItems)
            {               
                if ((pickedDateTime.TimeOfDay >= item.Open_Hour.TimeOfDay) && (pickedDateTime.TimeOfDay < item.Close_Hour.TimeOfDay) && (selectedItem.Name == item.Name) && (pickedDateTime.Date.Day == item.Open_Hour.Date.Day) && (pickedDateTime.Date.Day == item.Close_Hour.Date.Day))
                {
                    _matchingItems.Add(item);
                    //czujka ze do tego dochodzi
                    //MessageBox.Show(_matchingItems.ToString());
                }
                else if((pickedDateTime.TimeOfDay >= item.Open_Hour.TimeOfDay) && (pickedDateTime.TimeOfDay < item.Close_Hour.TimeOfDay) &&(pickedDateTime.Date.Day == item.Open_Hour.Date.Day) && (pickedDateTime.Date.Day == item.Close_Hour.Date.Day) && selectedItem.Name == "Select All")
                {
                    _matchingItems.Add(item);
                }
            }
            if(MatchingItems.Count == 0)
            {
                MessageBox.Show("There is no available pitches on chosen time or date");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime pickedDateTime = DateTime.Now;
        public DateTime PickedDateTime
        {
            get { return pickedDateTime; }
            set
            {
                pickedDateTime = value;
                OnPropertyChanged("New pickedDateTime");
                Debug.Write(pickedDateTime.ToString());
            }
        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void execute(object obj)
        {
            
         
        }
        
        private bool canExecute(object parameter)
        {
            if (this._orlikItems == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ObservableCollection<ORLIK_DATABASE1> _orlikItems = new ObservableCollection<ORLIK_DATABASE1>();
        public ObservableCollection<ORLIK_DATABASE1> orlikItems
        {

            get
            {                          
                return _orlikItems;
            }
            set
            {
                _orlikItems = value;
                OnPropertyChanged("OrlikItems");
            }
        }
        public void GetOrlikList()
        {
            var orlikList = context.ORLIK_DATABASE1.ToList();
            foreach (var item in orlikList)
            {                
                _orlikItems.Add(item);
            }
            _orlikItems.Add(new ORLIK_DATABASE1() { Name = "Select All" });
        }
    }


        /*CodeFirstDemoEntities context = new CodeFirstDemoEntities();
       foreach (var i in data)
       {
           //Console.WriteLine("ID = {0}, Name = {1}, Adress = {2}, Date = {3}, Open Hours = {4}\n",i.Id,i.Name,i.Adress, i.Date, i.Open_Hours.GetType());
       }
       //Console.WriteLine("\n");

       var x = from dates in data
               where dates.Name != null
               select dates;
       foreach (var y in x)
       {
           //Console.WriteLine(y);
       }
       */


    }
        




 



        


   
    


    //ButtonCommand = new RelayCommand(o => Button_Click());
    /*private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        PickedDateTime = PickedDateTime.AddHours(1);
        //bool sth = PickedDateTime.TimeOfDay > DateTime.Now.TimeOfDay;
        //try
        //{
        //    var time = "12:00:00";
        //    var x = picker.Value;
        //    var y = x.GetType().ToString();

        //    MessageBox.Show(y);

        //}
        //catch (NullReferenceException ex)
        //{

        //}

    }
    */




   
