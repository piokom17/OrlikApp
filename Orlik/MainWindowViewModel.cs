﻿using System;
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
        }
        private CodeFirstDemoEntities context = new CodeFirstDemoEntities();
        
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime pickedDateTime = DateTime.Now;
        public DateTime PickedDateTime
        {
            get { return pickedDateTime; }
            set
            {
                pickedDateTime = value;
                OnPropertyChanged();
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




        private string orlikItem;
        public string OrlikItem
        {
            get { return orlikItem; }

            set
            {
                if (orlikItem != value)
                {
                    orlikItem = value;

                    OnPropertyChanged("OrlikItem");
                    Debug.Write(orlikItem.ToString());


                }
            }
        }
        private List<ORLIK_DATABASE1> _orlikItems = new List<ORLIK_DATABASE1>();
        public List<ORLIK_DATABASE1> orlikItems
        {

            get
            {

                /*var orlikList = context.ORLIK_DATABASE1.ToList();
                foreach (var item in orlikList)
                {
                    orlikItem = item.ToString();
                    orlikItems.Add(item);


                }
                OnPropertyChanged("orlikItem");
                //OrlikItem = orlikItem;
                return orlikItems;
                */
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




   
