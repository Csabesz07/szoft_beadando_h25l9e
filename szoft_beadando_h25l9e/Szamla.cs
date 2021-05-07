using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szoft_beadando_h25l9e
{
    class Szamla
    {
        /// <summary>
        /// A számla tulajdonosa
        /// </summary>
        public string tulajdonos { get; set; }

        /// <summary>
        /// A számla egyenlege
        /// </summary>
        public int egyenleg { get; set; }

        /// <summary>
        /// A számlák egyenlegfeltöltéséhez használt algoritmus!
        /// </summary>
        public string Feltoltes(int osszeg)
        {
            egyenleg = egyenleg + osszeg;
            return $"{egyenleg}";
        }

        /// <summary>
        /// Egyik számláról utalás a másik számlára!
        /// </summary>
        public void Utalas(int osszeg, Szamla masikSzamla)
        {
            egyenleg = egyenleg - osszeg;
            masikSzamla.egyenleg = masikSzamla.egyenleg + osszeg;
        }

        /// <summary>
        /// A számláról pénzkivételhez használt algoritmus!
        /// </summary>
        public string Kivetel(int osszeg)
        {
            egyenleg = egyenleg - osszeg;
            return $"{egyenleg}";
        }


        /// <summary>
        /// A tulajdonos váltására szolgáló algoritmus!
        /// </summary>
        public string Tulajvaltas(string ujTulaj)
        {
            tulajdonos = ujTulaj;
            return $"{tulajdonos}";
        }
    }
}
