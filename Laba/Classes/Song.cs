namespace labatym9
{
    
    class Song
    {
        #region Поля
        private string songName;
        private string songAuthor;
        private Song previousSong;
        #endregion

        #region Свойства
        
        public string SongName
        {
            get
            {
                return songName;
            }
        }
        
        public string SongAuthor
        {
            get
            {
                return songAuthor;
            }
        }
       
        public Song PreviousSong
        {
            get
            {
                return previousSong;
            }
        }
       
        public string Title
        {
            get
            {
                return songName + " " + songAuthor;
            }
        }
        #endregion

        #region Методы
        
        public override bool Equals(object transmittedSong)
        {
            Song song = transmittedSong as Song;

            if ((song != null) && (song.SongName == songName) && (song.SongAuthor == songAuthor))
            {
                return true;
            }

            return false;
        }

        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Конструкторы
       
        public Song(string songName, string songAuthor, Song previousSong)
        {
            this.songName = songName;
            this.songAuthor = songAuthor;
            this.previousSong = previousSong;
        }

       
        public Song(string songName, string songAuthor)
        {
            this.songName = songName;
            this.songAuthor = songAuthor;
            previousSong = null;
        }

       
        public Song()
        {
            songName = "Не указано";
            songAuthor = "Не указано";
            previousSong = null;
        }
        #endregion
    }
}