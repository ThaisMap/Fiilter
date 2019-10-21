using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Fiilter
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private Principal MainOne;
        ICollectionView Source;
        private List<string> SetoresSelecionados;
        public MainWindow()
        {
            InitializeComponent();
            MainOne = new Principal();
            Source = CollectionViewSource.GetDefaultView(MainOne.FIIs);
            dgFIIs.ItemsSource = Source;
            listSetores.ItemsSource = MainOne.setores;
            SetoresSelecionados = MainOne.setores.ToList();
        }

        private void LostFocus_Filtrar(object sender, RoutedEventArgs e)
        {
            try
            {
                Source.Filter = new Predicate<object>(GetFilteredView);
            }
            catch (Exception)
            { }
        }

        private void ApenasNumeros(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9](/.[0-9]+)");//^[0-9](\.[0-9]+)?$ -- ^-?[0-9]*\.?[0-9]+$
            e.Handled = regex.IsMatch(e.Text);
        }

        public bool GetFilteredView(object sourceObject)
        {
            FII fundo = sourceObject as FII;
            return (FiltroSetor(fundo) && FiltroValor(fundo) && FiltroLiquidez(fundo) && FiltroDYMedia12(fundo) && FiltroPVPA(fundo) && FiltroQtAtivos(fundo) && FiltroVacancia(fundo));
          
        }

        private bool FiltroValor(FII fundo)
        {
            if (tbValor.Text == "")
                return true;

            if (!int.TryParse(tbValor.Text, out int valor))
                return false;

            return fundo.PrecoAtual <= valor;
        }

        private bool FiltroLiquidez(FII fundo)
        {
            if (tbLiquidez.Text == "")
                return true;

            if (!int.TryParse(tbLiquidez.Text, out int liquidez))
                return false;

            return fundo.Liquidez >= liquidez;
        }

        private bool FiltroDYMedia12(FII fundo)
        {
            if (tbDY12Media.Text == "")
                return true;

            if (!decimal.TryParse(tbDY12Media.Text, out decimal DYMedia))
                return false;

            return fundo.DY12Media >= DYMedia;
        }

        private bool FiltroPVPA(FII fundo)
        {
            if (tbPvpa.Text == "")
                return true;

            if (!decimal.TryParse(tbPvpa.Text, out decimal valor))
                return false;

            return fundo.PVPA <= valor;
        }

        private bool FiltroQtAtivos(FII fundo)
        {
            if (tbQtdeAtivos.Text == "")
                return true;

            if (!int.TryParse(tbQtdeAtivos.Text, out int ativos))
                return false;

            return fundo.QtdeAtivos >= ativos;
        }

        private bool FiltroSetor(FII fundo)
        {
            if (SetoresSelecionados.Count == 0)
                return true;

            else
                return SetoresSelecionados.Contains(fundo.Setor);            
        }

        private bool FiltroVacancia(FII fundo)
        {
            if (tbVacancia.Text == "")
                return true;

            if (!decimal.TryParse(tbVacancia.Text, out decimal valor))
                return false;

            return fundo.VacanciaFisica <= valor;
        }

        private void CkbSetor_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            SetoresSelecionados.Add(chkZone.Content.ToString());
            LostFocus_Filtrar(sender, e);
        }

        private void CkbSetor_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            SetoresSelecionados.Remove(chkZone.Content.ToString());
            LostFocus_Filtrar(sender, e);
        }
    }

  
}
