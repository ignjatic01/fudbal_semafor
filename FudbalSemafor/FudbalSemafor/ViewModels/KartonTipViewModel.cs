using FudbalSemafor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FudbalSemafor.ViewModels
{
    internal class KartonTipViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<KartonTip> KartonTips { get; set; }
        public KartonTip NewKartonTip { get; set; }
        private KartonTip _selectedKartonTip;
        public KartonTip SelectedKartonTip
        {
            get => _selectedKartonTip;
            set
            {
                if(value != _selectedKartonTip)
                {
                    _selectedKartonTip = value;
                    OnPropertyChanged(nameof(SelectedKartonTip));
                }
            }
        }

        public ICommand AddKartonTipCommand { get; set; }
        public ICommand EditKartonTipCommand { get; set; }
        public ICommand DeleteKartonTipCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public KartonTipViewModel()
        {
            context = new SemaforDbContext();
            var kartonTips = context.KartonTips.ToList();
            KartonTips = new ObservableCollection<KartonTip>();
            foreach ( var kartonTip in kartonTips )
            {
                KartonTips.Add( kartonTip );
            }
            NewKartonTip = new KartonTip();
            AddKartonTipCommand = new RelayCommand(AddKartonTip);
            EditKartonTipCommand = new RelayCommand(EditKartonTip);
            DeleteKartonTipCommand = new RelayCommand(DeleteKartonTip);
        }

        public void AddKartonTip()
        {
            if (!string.IsNullOrWhiteSpace(NewKartonTip.Tip))
            {
                try
                {
                    context.KartonTips.Add(NewKartonTip);
                    context.SaveChanges();

                    KartonTips.Add(NewKartonTip);

                    NewKartonTip = new KartonTip();
                    OnPropertyChanged(nameof(NewKartonTip));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void EditKartonTip()
        {
            if (!string.IsNullOrWhiteSpace(SelectedKartonTip.Tip))
            {
                try
                {
                    var existingKartonTip = context.KartonTips.FirstOrDefault(kt => kt.IdKartonTip == SelectedKartonTip.IdKartonTip);
                    if (existingKartonTip != null)
                    {
                        existingKartonTip.Tip = SelectedKartonTip.Tip;

                        context.SaveChanges();

                        var index = KartonTips.IndexOf(SelectedKartonTip);
                        if (index != -1)
                        {
                            KartonTips[index] = existingKartonTip;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tip kartona nije pronadjen.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteKartonTip()
        {
            if (SelectedKartonTip != null)
            {
                try
                {
                    var existingKartonTip = context.KartonTips.FirstOrDefault(kt => kt.IdKartonTip == SelectedKartonTip.IdKartonTip);
                    if(existingKartonTip != null)
                    {
                        context.KartonTips.Remove(existingKartonTip);
                        context.SaveChanges();
                        KartonTips.Remove(SelectedKartonTip);
                        SelectedKartonTip = null;
                    }
                    else
                    {
                        MessageBox.Show("Tip kartona nije pronadjen.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
