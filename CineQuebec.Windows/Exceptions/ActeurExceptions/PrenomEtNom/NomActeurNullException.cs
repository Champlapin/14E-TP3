﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Exceptions.ActeurExceptions.PrenomEtNom
{
    public class NomActeurNullException(string message) : ActeurException(message)
    {
    }
}