using System;
using Microsoft.Maui.Controls;

namespace SportsSupporter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnExerciseTypeChanged(object sender, EventArgs e)
        {
            if (ExerciseTypePicker.SelectedItem as string == "Podnoszenie ciężarów")
            {
                DistanceStackLayout.IsVisible = false;
                SeriesStackLayout.IsVisible = true;
            }
            else
            {
                DistanceStackLayout.IsVisible = true;
                SeriesStackLayout.IsVisible = false;
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            string exerciseType = ExerciseTypePicker.SelectedItem as string;
            if (string.IsNullOrEmpty(exerciseType))
            {
                DisplayAlert("Błąd", "Wybierz rodzaj ćwiczenia", "OK");
                return;
            }

            double time = 0;
            double distance = 0;
            int repetitions = 0;
            int series = 0;

            if (!double.TryParse(TimeEntry.Text, out time))
            {
                DisplayAlert("Błąd", "Wprowadź poprawny czas w minutach", "OK");
                return;
            }

            if (exerciseType != "Podnoszenie ciężarów" && !double.TryParse(DistanceEntry.Text, out distance))
            {
                DisplayAlert("Błąd", "Wprowadź poprawny dystans w km", "OK");
                return;
            }

            if (!int.TryParse(RepetitionsEntry.Text, out repetitions))
            {
                DisplayAlert("Błąd", "Wprowadź poprawną liczbę powtórzeń", "OK");
                return;
            }

            if (exerciseType == "Podnoszenie ciężarów" && !int.TryParse(SeriesEntry.Text, out series))
            {
                DisplayAlert("Błąd", "Wprowadź poprawną liczbę serii", "OK");
                return;
            }

            double calories = 0;

            switch (exerciseType)
            {
                case "Bieganie":
                    calories = (time * 10.0) + (distance * 60);
                    break;
                case "Pływanie":
                    calories = (time * 8.5) + (distance * 50);
                    break;
                case "Podnoszenie ciężarów":
                    calories = (repetitions * 0.3) + (series * 1.5) + (time * 5.0);
                    break;
                default:
                    DisplayAlert("Błąd", "Wybierz prawidłowy rodzaj ćwiczenia", "OK");
                    return;
            }

            ResultLabel.Text = $"Typ ćwiczenia: {exerciseType}\nCzas: {time} min, Dystans: {distance} km, Powtórzenia: {repetitions}, Serii: {series}\nSpalone kalorie: {calories} kcal";
        }
    }
}
