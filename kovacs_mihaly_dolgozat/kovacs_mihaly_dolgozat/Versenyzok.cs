using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kovacs_mihaly_dolgozat
{
    internal class Versenyzok
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Rajtszam { get; set; }
        public bool Sex { get; set; }
        public string Category { get; set; }
        public TimeSpan Uszas { get; set; }
        public TimeSpan Elsodepo { get; set; }
        public TimeSpan Kerekpar { get; set; }
        public TimeSpan Masodikdepo { get; set; }
        public TimeSpan Futas { get; set; }

      

        public Versenyzok(string row) {
            var v = row.Split(";");
            Name = v[0];
            Year=int.Parse(v[1]);
            Rajtszam = int.Parse(v[2]);
            if (v[3] == "f")
            {
                Sex= true;
            }
            else
            {
                Sex= false;
            }
            Category = v[4];
            Uszas = TimeSpan.Parse(v[5]);
            Elsodepo = TimeSpan.Parse(v[6]);
            Kerekpar = TimeSpan.Parse(v[7]);
            Masodikdepo = TimeSpan.Parse(v[8]);
            Futas = TimeSpan.Parse(v[9]);

        }
        public override string ToString() =>
            $"{Name} - {(Sex ? "Férfi":"Nő")}: ({Year}-ben született, {Rajtszam}-s rajtszámmal. {Category} kategóriában. Idejei:" +
           $"\n {Uszas}\t {Elsodepo}\t {Kerekpar}\t {Masodikdepo}\t {Futas}";

    }
}
