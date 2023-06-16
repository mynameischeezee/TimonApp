using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timon.Maui.ViewModels.Recommendations;

namespace Timon.Maui.Views.Recommendations;

public partial class RecommendationsPage : ContentPage
{
    public RecommendationsPage(RecommendationViewModel recommendationViewModel)
    {
        InitializeComponent();
        this.BindingContext = recommendationViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as RecommendationViewModel)?.Update();
    }
}