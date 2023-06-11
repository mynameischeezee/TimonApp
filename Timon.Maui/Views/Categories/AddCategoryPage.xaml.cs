using Timon.Maui.ViewModels.Categories;

namespace Timon.Maui.Views.Categories;

public partial class AddCategoryPage : ContentPage
{
    public AddCategoryPage(AddCategoryViewModel addCategoryViewModel)
    {
        InitializeComponent();
        this.BindingContext = addCategoryViewModel;
    }
}