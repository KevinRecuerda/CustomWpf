using CustomWpf.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CustomWpf.ViewModel
{
    public class MonitoringViewModel : ViewModelBase
    {
        private ObservableCollection<AppStateView> appStates;
        private AppStateView selectedAppState;

        public ObservableCollection<AppStateView> AppStates
        {
            get { return this.appStates; }
            set { this.Set(ref this.appStates, value); }
        }
        public AppStateView SelectedAppState
        {
            get { return this.selectedAppState; }
            set { this.Set(ref this.selectedAppState, value); }
        }

        public MonitoringViewModel()
        {
            var items = new List<AppStateView>();
            foreach (Platform platform in typeof (Platform).GetEnumValues())
            {
                items.AddRange(this.GetAppStates(platform));
            }
            this.AppStates = new ObservableCollection<AppStateView>(items);
        }

        public List<AppStateView> GetAppStates(Platform platform)
        {
            return new List<AppStateView>()
            {
                new AppStateView(platform, new AppState("App 1",             AppGroup.GameGroup)),
                new AppStateView(platform, new AppState("App mario",         AppGroup.GameGroup)),
                new AppStateView(platform, new AppState("App fight list",    AppGroup.GameGroup) { Status = AppStatus.Stopped }),
                new AppStateView(platform, new AppState("App peek",          AppGroup.GameGroup) { Status = AppStatus.Indeterminated }),
                new AppStateView(platform, new AppState("App clash royal",   AppGroup.GameGroup)),
                new AppStateView(platform, new AppState("App clash of clan", AppGroup.GameGroup)),
                new AppStateView(platform, new AppState("App kayak",         AppGroup.TravelGroup)),
                new AppStateView(platform, new AppState("App trivago",       AppGroup.TravelGroup)),
                new AppStateView(platform, new AppState("App ouigo",         AppGroup.TravelGroup)),
                new AppStateView(platform, new AppState("App sncf",          AppGroup.TravelGroup)),
                new AppStateView(platform, new AppState("App blablacar",     AppGroup.TravelGroup)),
                new AppStateView(platform, new AppState("App ...",           AppGroup.TravelGroup)),
                new AppStateView(platform, new AppState("App maps",          AppGroup.ToolsGroup)),
                new AppStateView(platform, new AppState("App waze",          AppGroup.ToolsGroup)),
            };
        }
    }
}