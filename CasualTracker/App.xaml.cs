using CasualTracker.Model;
using CasualTracker.Persistence;
using CasualTracker.Views;
namespace CasualTracker
{
    public partial class App : Application
    {
        CasualTrackerModel Model;
        ICasualTrackerPersistence Persistence;
        NavigationPage Rootpage;
        public App() 
        {
            InitializeComponent();
            Persistence = new JSONPersistence("shifts.dat", "workplaces.dat");
            Model = new CasualTrackerModel(Persistence);

            Model.ShiftSelected += Model_ShiftSelected;
            Model.ReturnPreviousPage += Model_ReturnPreviousPage;
            Model.LoadWorkplacePage += Model_LoadWorkplacePage;

            Rootpage = new NavigationPage(new MainPage(Model));
            MainPage = Rootpage;

        }

        private async void Model_LoadWorkplacePage(object? sender, EventArgs e)
        {
            await Rootpage.PushAsync(new AddWorkplacePage(Model));
        }

        private async void Model_ReturnPreviousPage(object? sender, EventArgs e)
        {
            await Rootpage.PopAsync();
        }

        private async void Model_ShiftSelected(object? sender, EventArgs e)
        {
            await Rootpage.PushAsync(new ShiftPage(Model));
        }

        protected override void OnStart()
        {
            base.OnStart();
            //Model.LoadData();
        }



    }
}
