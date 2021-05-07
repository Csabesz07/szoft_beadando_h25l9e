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

namespace szoft_beadando_h25l9e
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Az első számlát tartalmazó objektum
        /// </summary>
        Szamla szamla1 = new Szamla();

        /// <summary>
        /// A második számlát tartalmazó objektum!
        /// </summary>
        Szamla szamla2 = new Szamla();

        /// <summary>
        /// Az első számlára való feltöltésre szolgáló algoritmus.
        /// </summary>
        private void feltoltes1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(BeviteliMezo1.Text) > 0)
                {
                    szamla1.egyenleg = int.Parse(SzamlaEgyenleg1.Text);
                    SzamlaEgyenleg1.Text = szamla1.Feltoltes(int.Parse(BeviteliMezo1.Text));
                    Tisztito(BeviteliMezo1);
                }
                else BeviteliMezo1.Text = "A beírt összeg nem lehet negatív szám!";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                BeviteliMezo1.Clear();
            }
        }

        /// <summary>
        /// A második számlára való feltöltésre szolgáló algoritmus!
        /// </summary>
        private void feltoltes2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(BeviteliMezo2.Text) > 0)
                {
                    szamla2.egyenleg = int.Parse(SzamlaEgyenleg2.Text);
                    SzamlaEgyenleg2.Text = szamla2.Feltoltes(int.Parse(BeviteliMezo2.Text));
                    Tisztito(BeviteliMezo2);
                }
                else BeviteliMezo2.Text = "A beírt összeg nem lehet negatív szám!";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                BeviteliMezo2.Clear();
            }
        }


        /// <summary>
        /// Az első számláról utalás a második számlára!
        /// </summary>
        private void utalas1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(BeviteliMezo1.Text) > 0)
                {
                    if (int.Parse(SzamlaEgyenleg1.Text) >= int.Parse(BeviteliMezo1.Text))
                    {
                        szamla1.egyenleg = int.Parse(SzamlaEgyenleg1.Text);
                        szamla2.egyenleg = int.Parse(SzamlaEgyenleg2.Text);
                        szamla1.Utalas(int.Parse(BeviteliMezo1.Text), szamla2);
                        SzamlaEgyenleg1.Text = Convert.ToString(szamla1.egyenleg);
                        SzamlaEgyenleg2.Text = Convert.ToString(szamla2.egyenleg);
                        Tisztito(BeviteliMezo1);
                    }
                    else BeviteliMezo1.Text = "A számla nem mehet minuszba!";
                }
                else BeviteliMezo1.Text = "A beírt összeg nem lehet negatív szám!";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                BeviteliMezo1.Clear();
            }

        }


        /// <summary>
        /// A második számláról utalás az első számlára!
        /// </summary>
        private void utalas2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(BeviteliMezo2.Text) > 0)
                {
                    if (int.Parse(SzamlaEgyenleg2.Text) >= int.Parse(BeviteliMezo2.Text))
                    {
                        szamla2.egyenleg = int.Parse(SzamlaEgyenleg2.Text);
                        szamla1.egyenleg = int.Parse(SzamlaEgyenleg1.Text);
                        szamla2.Utalas(int.Parse(BeviteliMezo2.Text), szamla1);
                        SzamlaEgyenleg2.Text = Convert.ToString(szamla2.egyenleg);
                        SzamlaEgyenleg1.Text = Convert.ToString(szamla1.egyenleg);
                        Tisztito(BeviteliMezo2);
                    }
                    else BeviteliMezo2.Text = "A számla nem mehet minuszba!";
                }
                else BeviteliMezo2.Text = "A beírt összeg nem lehet negatív szám!";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                BeviteliMezo2.Clear();
            }
        }


        /// <summary>
        /// Az első számla tulajdonosának a lecserélése.
        /// </summary>
        private void tulajvaltas1_Click(object sender, RoutedEventArgs e)
        {
            TulajNev1.Text = szamla1.Tulajvaltas(BeviteliMezo1.Text);
            Tisztito(BeviteliMezo1);
        }


        /// <summary>
        /// A második számla tulajdonosának a lecserélése.
        /// </summary>
        private void tulajvaltas2_Click(object sender, RoutedEventArgs e)
        {
            TulajNev2.Text = szamla2.Tulajvaltas(BeviteliMezo2.Text);
            Tisztito(BeviteliMezo2);
        }


        /// <summary>
        /// Az első számláról pénzkivétel.
        /// </summary>
        private void kivet1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(BeviteliMezo1.Text) > 0)
                {
                    if (int.Parse(SzamlaEgyenleg1.Text) >= int.Parse(BeviteliMezo1.Text))
                    {
                        szamla1.egyenleg = int.Parse(SzamlaEgyenleg1.Text);
                        SzamlaEgyenleg1.Text = szamla1.Kivetel(int.Parse(BeviteliMezo1.Text));
                        Tisztito(BeviteliMezo1);
                    }
                    else BeviteliMezo1.Text = "A számla nem mehet minuszba!";
                }
                else BeviteliMezo1.Text = "A beírt összeg nem lehet negatív szám!";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                BeviteliMezo1.Clear();
            }
        }


        /// <summary>
        /// A második számláról pénzkivétel.
        /// </summary>
        private void kivet2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(BeviteliMezo2.Text) > 0)
                {
                    if (int.Parse(SzamlaEgyenleg2.Text) >= int.Parse(BeviteliMezo2.Text))
                    {
                        szamla2.egyenleg = int.Parse(SzamlaEgyenleg2.Text);
                        SzamlaEgyenleg2.Text = szamla2.Kivetel(int.Parse(BeviteliMezo2.Text));
                        Tisztito(BeviteliMezo2);
                    }
                    else BeviteliMezo2.Text = "A számla nem mehet minuszba!";
                }
                else BeviteliMezo2.Text = "A beírt összeg nem lehet negatív szám!";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                BeviteliMezo2.Clear();
            }
        }

        /// <summary>
        /// Kiüríti a beviteli mezőt!
        /// </summary>
        public static string Tisztito(TextBox textBox)
        {
            return textBox.Text = string.Empty;
        }
    }
}
