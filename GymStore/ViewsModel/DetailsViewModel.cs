using GymStore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymStore.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        ObservableCollection<Supplement> supplements;
        public ObservableCollection<Supplement> Supplements
        {
            get { return supplements; }
            set
            {
                supplements = value;
                OnPropertyChanged();
            }
        }

        private Supplement selectedSupplement;
        public Supplement SelectedSupplement
        {
            get { return selectedSupplement; }
            set
            {
                selectedSupplement = value;
                OnPropertyChanged();
            }
        }

        private int position;
        public int Position
        {
            get
            {
                if (position != supplements.IndexOf(selectedSupplement))
                    return supplements.IndexOf(selectedSupplement);

                return position;
            }
            set
            {
                position = value;
                selectedSupplement = supplements[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedSupplement));
            }
        }

        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction = (string)obj;

            if (direction == "L")
            {
                if (position == 0)
                {
                    Position = supplements.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (position == supplements.Count - 1)
                {
                    Position = 0;
                    return;
                }

                Position += 1;
            }

        }

    }
}
