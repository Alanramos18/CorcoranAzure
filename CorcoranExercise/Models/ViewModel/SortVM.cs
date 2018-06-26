using CorcoranExercise.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorcoranExercise.Models.ViewModel
{
    /// <summary>
    /// ViewModel for Sort Service
    /// </summary>
    public class SortVM
    {
        //This is an enum which has the column name of that column will be sort (Birthday or Deathday)
        public ColumnName Name { get; set; }
        public bool IsAscending { get; set; }
    }
}