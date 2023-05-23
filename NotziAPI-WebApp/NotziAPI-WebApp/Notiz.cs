namespace NotziAPI_WebAPP
{
    public class Notiz
    {
        public string id { get; set; }
        public string titel { get; set; }
        public string text { get; set; }
        public string creationDate { get; set; }
        public string tag { get; set; }

        public Notiz()
        {

        }
        public Notiz(string id, string titel, string text, string tag)
        {
            this.id = id;
            this.titel = titel;
            this.text = text;
            this.tag = tag;
        }
    }
}
