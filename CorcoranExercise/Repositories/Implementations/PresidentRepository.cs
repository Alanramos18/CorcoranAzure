using CorcoranExercise.Models;
using CorcoranExercise.Models.Entities;
using CorcoranExercise.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CorcoranExercise.Utilities;
using CorcoranExercise.Models.ViewModel;

namespace CorcoranExercise.Repositories.Implementations
{
    public class PresidentRepository : IPresidentRepository
    {
        private PresidentServiceContext context;

        public PresidentRepository()
        {
            context = new PresidentServiceContext();
        }

        public List<President> GetAll()
        {
            try
            {
                List<President> list = new List<President>();

                foreach (System.Data.DataTable table in context.DtSet.Tables)
                {
                    foreach (System.Data.DataRow row in table.Rows)
                    {
                        //Creates the president object
                        var president = new President()
                        {
                            Name = row["President"].ToString(),
                            Birthday = Convert.ToDateTime(row["Birthday"]),
                            Birthplace = row["Birthplace"].ToString(),
                            Deathday = row["Death day"].ToString() == "" ? (DateTime?)null : Convert.ToDateTime(row["Death day"]),
                            Deathplace = row["Death place"].ToString()
                        };

                        list.Add(president);
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<President> Get(string name)
        {
            try
            {
                var list = GetAll();

                return list.Where(x => x.Name.Contains(name)).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<President> ChangeOrder(SortVM viewModel)
        {
            try
            {
                var list = GetAll();

                switch (viewModel.Name)
                {
                    case ColumnName.BirthDay:
                        if (viewModel.IsAscending)
                            return list.OrderBy(x => !x.Deathday.HasValue)
                                .ThenBy(x => x.Birthday)
                                .ToList();
                        else
                            return list.OrderByDescending(x => x.Deathday.HasValue)
                                .ThenByDescending(x => x.Birthday)
                                .ToList();

                    case ColumnName.DeathDay:
                        if (viewModel.IsAscending)
                            return list.OrderBy(x => !x.Deathday.HasValue)
                                .ToList();
                        else
                            return list.OrderByDescending(x => x.Deathday.HasValue)
                                .ThenByDescending(x => x.Deathday)
                                .ToList();
                    default:
                        throw new Exception("Wrong Column Name");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}