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
            Persistence = new CasualTrackerPersistence();
            Model = new CasualTrackerModel(Persistence);

            Model.ShiftSelected += Model_ShiftSelected;

            Rootpage = new NavigationPage(new MainPage(Model));
            MainPage = Rootpage;

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
