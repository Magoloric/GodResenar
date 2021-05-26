using System.IO;
using Xamarin.Forms;

namespace GodResenar.Functions
{
    class Report
    {
        private string userName;
        private string textMessage;
        private string location;
        private string title;
        private string photoSource;
        private string videoSource;
        private string voiceMessageSource;
        private Image photoAttached;
        private Stream videoAttached;
        private Stream voiceMessage;
        private int votes;
        private int number;

        public enum Status
        {
            Pending,
            Accepted,
            InProgress,
            Solved,
            Rejected,
        }

        public enum Category
        {
            Delay,
            TicketWending,
            Overcrowd,
            TransportDamage,
            BusStopIssue,
            Advice,
            Other
        }

        public string UserName { get => userName; set => userName = value; }
        public string TextMessage { get => textMessage; set => textMessage = value; }
        public Image PhotoAttached { get => photoAttached; set => photoAttached = value; }
        public Stream VideoAttached { get => videoAttached; set => videoAttached = value; }
        public Stream VoiceMessage { get => voiceMessage; set => voiceMessage = value; }
        public int Votes { get => votes; set => votes = value; }
        public string Location { get => location; set => location = value; }
        public string Title { get => title; set => title = value; }
        public int Number { get => number; set => number = value; }
        public string PhotoSource { get => photoSource; set => photoSource = value; }
        public string VideoSource { get => videoSource; set => videoSource = value; }
        public string VoiceMessageSource { get => voiceMessageSource; set => voiceMessageSource = value; }
    }
}
