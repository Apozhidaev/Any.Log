namespace Ap.Logs.Tests.Loggers.Emails
{
    internal class EmailModel
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string[] Attachmets { get; set; }
    }
}