using Microsoft.Maui.Controls;

namespace SportsSupporter
{
    public partial class Plany : ContentPage
    {
        public Plany()
        {
            InitializeComponent();
        }

        private void OnShowPlanClicked(object sender, EventArgs e)
        {
            string skillLevel = SkillLevelPicker.SelectedItem as string;

            if (string.IsNullOrEmpty(skillLevel))
            {
                DisplayAlert("B��d", "Wybierz poziom zaawansowania", "OK");
                return;
            }

            string trainingPlan = skillLevel switch
            {
                "poczatkujacy" => "Plan dla poczatkujacych:\n1. Rozgrzewka (10 min)\n2. Marszobieg (20 min)\n3. Rozci�ganie (10 min).",
                "srednio" => "Plan dla �rednio zaawansowanych:\n1. Rozgrzewka (15 min)\n2. Bieg (30 min)\n3. Si�owe (20 min)\n4. Rozci�ganie (10 min).",
                "Zaawansowany" => "Plan dla zaawansowanych:\n1. Rozgrzewka (15 min)\n2. Interwa�y (40 min)\n3. Si�owe (30 min)\n4. Rozci�ganie (15 min).",
                _ => "Nieznany poziom zaawansowania."
            };

            PlanLabel.Text = trainingPlan;
        }
    }
}
