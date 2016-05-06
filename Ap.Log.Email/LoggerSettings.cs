namespace Ap.Logs.Email
{
    public class LoggerSettings
    {
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public int Period { get; set; }
        public string[] Methods { get; set; }
    }
}