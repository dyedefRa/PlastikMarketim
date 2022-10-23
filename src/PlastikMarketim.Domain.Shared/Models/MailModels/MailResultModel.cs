namespace PlastikMarketim.Models.MailModels
{
    public class MailResultModel
    {
        public string Subject { get; set; }
        public string Template { get; set; }
        public bool Status { get; set; } = true;
    }
}
