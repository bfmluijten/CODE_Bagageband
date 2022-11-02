using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CODE_Bagageband.Model
{
    public class Vlucht : Observable<Vlucht>
    {
        private Timer _waitingTimer;

        public TimeSpan TimeWaiting;

        public Vlucht(string vertrokkenVanuit, int aantalKoffers)
        {
            VertrokkenVanuit = vertrokkenVanuit;
            AantalKoffers = aantalKoffers;

            _waitingTimer = new Timer();
            _waitingTimer.Interval = 1000;
            _waitingTimer.Tick += WeerEenSecondeVoorbij;
            _waitingTimer.Start();
        }

        private void WeerEenSecondeVoorbij(object sender, EventArgs e)
        {
            TimeWaiting = TimeWaiting.Add(new TimeSpan(0, 0, 1));

            Notify(this);
        }

        private string _vertrokkenVanuit;
        public string VertrokkenVanuit
        {
            get { return _vertrokkenVanuit; }
            set { _vertrokkenVanuit = value; } // TODO: Kunnen we hier straks net zoiets doen als RaisePropertyChanged?
        }

        private int _aantalKoffers;
        public int AantalKoffers
        {
            get { return _aantalKoffers; }
            set { _aantalKoffers = value; } // TODO: Kunnen we hier straks net zoiets doen als RaisePropertyChanged?
        }
    }
}
