﻿using CineQuebec.Windows.DAL.Data;
using CineQuebec.Windows.DAL.Entities;
using MongoDB.Bson;

namespace CineQuebec.Windows.ViewModel.ObservableClass
{
    public class ObservableNote : PropertyNotifier
    {
        private Note _note;
        private ObjectId _idFilm;

        public ObjectId IdFilm
        {
            get { return _idFilm; }
            set
            {
                _idFilm = value;
                OnPropertyChanged();
            }
        }

        private ObjectId _idAbonne;

        public ObjectId IdAbonne
        {
            get { return _idAbonne; }
            set
            {
                _idAbonne = value;
                OnPropertyChanged();
            }
        }
        private int _noteValue;

        public int NoteValue
        {
            get { return _noteValue; }
            set
            {
                _noteValue = value;
                OnPropertyChanged();
            }
        }
        public ObservableNote()
        {
            _note = new();   
        }
        public ObservableNote(Note note)
        {
            _note = note is null ? new() : note;
        }
        internal Note Value()
        {
            _note.FilmId = IdFilm;
            _note.AbonneId = IdAbonne;
            _note.NoteValue = NoteValue;
            return _note;
        }
        internal bool IsValid()
        {
            return NoteValue >= 0 || NoteValue <= 10;
        }
        public override string ToString()
        {
            return _note.ToString();
        }
    }
}