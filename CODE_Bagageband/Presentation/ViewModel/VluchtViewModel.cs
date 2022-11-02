using CODE_Bagageband.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_Bagageband.ViewModel
{
    public class VluchtViewModel : ViewModelBase, IObserver<Vlucht>
    {
        private string _vertrokkenVanuit;
        public string VertrokkenVanuit
        {
            get { return _vertrokkenVanuit; }
            set { _vertrokkenVanuit = value; RaisePropertyChanged("VertrokkenVanuit"); }
        }

        private int _aantalKoffers;
        public int AantalKoffers
        {
            get { return _aantalKoffers; }
            set { _aantalKoffers = value; RaisePropertyChanged("AantalKoffers"); }
        }

        private TimeSpan _timeWaiting;
        public TimeSpan TimeWaiting
        {
            get { return _timeWaiting; }
            set { _timeWaiting = value; RaisePropertyChanged("TimeWaiting"); }
        }

        public VluchtViewModel(Vlucht vlucht)
        {
            vlucht.Subscribe(this);

            Update(vlucht);
            // TODO: Vlucht is straks observable, kunnen we daar niet op abonneren?
        }

        public void Update(Vlucht vlucht)
        {
            // TODO: Dit mag natuurlijk naar de OnNext methode toe.
            VertrokkenVanuit = vlucht.VertrokkenVanuit;
            AantalKoffers = vlucht.AantalKoffers;
            TimeWaiting = vlucht.TimeWaiting;
        }

        public void OnNext(Vlucht vlucht)
        {
            Update(vlucht);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
