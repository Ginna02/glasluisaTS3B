using System;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

namespace glasluisaTS3B.Views
{
    public partial class vHome : ContentPage
    {
        public vHome()
        {
            InitializeComponent();
        }

        private void ControlRango(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            if (!regex.IsMatch(e.NewTextValue))
            {
                DisplayAlert("Entrada inválida", "Solo se permiten números", "OK");
                ((Entry)sender).Text = string.Empty;
            }
            else if (double.TryParse(e.NewTextValue, out double valor) && (valor < 0 || valor > 10))
            {
                DisplayAlert("Error", "El valor debe estar entre 0 y 10", "OK");
                ((Entry)sender).Text = string.Empty;
            }
        }

        private async void btnCalcular_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotaSeg1.Text) || 
                string.IsNullOrWhiteSpace(txtExamen1.Text) || 
                string.IsNullOrWhiteSpace(txtNotaSeg2.Text) || 
                string.IsNullOrWhiteSpace(txtExamen2.Text) || 
                pkEstudiantes.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            double notaSeg1 = Convert.ToDouble(txtNotaSeg1.Text) * 0.3;
            double examen1 = Convert.ToDouble(txtExamen1.Text) * 0.2;
            double notaParcial1 = notaSeg1 + examen1;

            double notaSeg2 = Convert.ToDouble(txtNotaSeg2.Text) * 0.3;
            double examen2 = Convert.ToDouble(txtExamen2.Text) * 0.2;
            double notaParcial2 = notaSeg2 + examen2;

            double notaFinal = notaParcial1 + notaParcial2;

            // Mostrar resultados en las etiquetas
            lblNotaParcial1.Text = $"Nota Parcial 1: {notaParcial1:F2}";
            lblNotaParcial2.Text = $"Nota Parcial 2: {notaParcial2:F2}";
            lblNotaFinal.Text = $"Nota Final: {notaFinal:F2}";

            // Determinar estado
            string estado = notaFinal >= 7 ? "Aprobado" :
                            (notaFinal >= 5 ? "Complementario" : "Reprobado");

            lblEstado.Text = $"Estado: {estado}";

            // Mensaje de resultados
            string mensaje = $"Nombre: {pkEstudiantes.SelectedItem}\n" +
                             $"Fecha: {dpkFecha.Date.ToShortDateString()}\n" +
                             $"Nota Parcial 1: {notaParcial1:F2}\n" +
                             $"Nota Parcial 2: {notaParcial2:F2}\n" +
                             $"Nota Final: {notaFinal:F2}\n" +
                             $"Estado: {estado}";

            await DisplayAlert("Nota drel estudiante", mensaje, "OK");
        }
    }
}
