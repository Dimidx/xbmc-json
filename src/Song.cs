namespace XbmcJson
{
    public class Song
    {
        private int _id;
        private string File;
        private string Label;
        private string Thumbnail;

        public int id
        {
            get
            {
                return _id;
            }
        }

        public string file
        {
            get
            {
                return File;
            }
        }

        public string label
        {
            get
            {
                return Label;
            }
        }

        public string thumbnail
        {
            get
            {
                return Thumbnail;
            }
        }

        public Song(int id, string file, string label, string thumbnail)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }
    }
}
