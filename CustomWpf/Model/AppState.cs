namespace CustomWpf.Model
{
    public class AppStateView
    {
        public AppStateView(Platform platform, AppState appState)
        {
            this.Platform = platform;
            this.AppState = appState;
        }

        public Platform Platform { get; set; }
        public AppState AppState { get; set; }
    }

    public enum Platform
    {
        Daily,
        Weekly,
        Monthly,
        Annual
    }

    public class AppState
    {
        public AppState(string name, AppGroup appGroup)
        {
            this.Name = name;
            this.AppGroup = appGroup;
        }

        public string Name { get; set; }
        public AppGroup AppGroup { get; set; }
        public AppStatus Status { get; set; }
    }

    public enum AppStatus
    {
        Running,
        Stopped,
        Indeterminated
    }

    public enum AppGroup
    {
        GameGroup,
        TravelGroup,
        ToolsGroup
    }
}