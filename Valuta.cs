using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ØkonomiSystemet
{
    public class Valuta
    {

        public string _Name { get; }
        public List<Valuta> _ValutaListe { get; }
        public int Listnumber { get; set; }

        public Valuta(string name)
        {
            _Name = name;
        }

        public Valuta()
        {
            _ValutaListe = new List<Valuta>();
            AddValuta();
            Listnumber = 0;
        }


        private void AddValuta()
        {
            _ValutaListe.Add(new Valuta("Nok"));
            _ValutaListe.Add(new Valuta("Usd"));
            _ValutaListe.Add(new Valuta("Euro"));
        }



         int HentValutaInput()
        {
            Console.WriteLine($"What currency would you like too choose?");
            return Convert.ToInt32(Console.ReadLine());
        }



        public void VisValuta()
        {
            Console.WriteLine();
            foreach (var valuta in _ValutaListe)
            {
                Listnumber++;
                Console.WriteLine($"{Listnumber}.Valuta: {valuta._Name}");
              
             
            }
        }

        public string getselectedValuta()
        {
            int selectedvaluta = HentValutaInput();
            if (selectedvaluta >= 1 && selectedvaluta <= _ValutaListe.Count)
            {
                return _ValutaListe[selectedvaluta -1]._Name;
            }
            else
            {
                Console.WriteLine("currency choice is invalid ");
                return null;
            }
        }
    }
}