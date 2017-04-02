﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.BusinessLogic
{
    public class Reservation
    {
        private int _idPassager;
        private int _idVoyage;
        private int _nbPassager;

        public int IdPassager
        {
            get { return _idPassager; }
            set { _idPassager = value; }
        }

        public int IdVoyage
        {
            get { return _idVoyage; }
            set { _idVoyage = value; }
        }

        public int NbPassager
        {
            get { return _nbPassager; }
            set { _nbPassager = value; }
        }

        public Reservation(int idPassager,int idVoyage, int nbPassager)
        {
            _idPassager = idPassager;
            _idVoyage = idVoyage;
            _nbPassager = nbPassager;
        }
    }
}
