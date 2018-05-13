using System;

namespace NewsSurvey.Classes
{
    class News
    {
        // News properties
        public string Number;
        public string Publisher;
        public string Url;
        public string Header;
        public string Text;

        // Survey results
        private Boolean ReliableSource { get; set; }
        private Boolean Emotional { get; set; }
        private int Reliability { get; set; }

        public News(string __number, string __publisher, string __url, string __header, string __text)
        {
            Publisher = __publisher;
            Url = __url;
            Header = __header;
            Text = __text;
        }

        public override string ToString()
        {
            return Number + ", " + Publisher + ", " + Url + ", " + Header + ", " + Text + "\n";
        }
    }
}
