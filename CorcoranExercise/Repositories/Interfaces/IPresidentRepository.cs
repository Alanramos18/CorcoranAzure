using CorcoranExercise.Models.Entities;
using CorcoranExercise.Models.ViewModel;
using CorcoranExercise.Utilities;
using System.Collections.Generic;

namespace CorcoranExercise.Repositories.Interfaces
{
    public interface IPresidentRepository
    {
        /// <summary>
        /// Bring the list of president
        /// </summary>
        /// <returns>List of President Entity</returns>
        List<President> GetAll();

        /// <summary>
        /// Get Presidents filter by name string
        /// </summary>
        /// <param name="name">Name of the president</param>
        /// <returns>President Entity</returns>
        List<President> Get(string name);

        /// <summary>
        /// Sort the list by Birthday/Deathday depending the string on the parameter.
        /// </summary>
        /// <param name="viewModel">SortVM: Contains Enum ColumnName and bool IsAscending</param>
        /// <returns>List of president ordered</returns>
        List<President> ChangeOrder(SortVM viewModel);
    }
}
