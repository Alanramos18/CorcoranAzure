using CorcoranExercise.Models.ViewModel;
using CorcoranExercise.Repositories.Interfaces;
using System;
using System.Net;
using System.Web.Http;

namespace CorcoranExercise.Controllers
{
    public class PresidentsController : ApiController
    {
        IPresidentRepository presidentRepository;

        public PresidentsController(IPresidentRepository _presidentRepository)
        {
            presidentRepository = _presidentRepository;
        }

        [HttpGet]
        public IHttpActionResult GetPresidentList()
        {
            try
            {
                return Ok(presidentRepository.GetAll());
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("/searchpresident/{name}")]
        public IHttpActionResult SearchPresident(string name)
        {
            try
            {
                if(name == null)
                {
                    throw new Exception("The name is empty");
                }

                return Ok(presidentRepository.Get(name));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("/changeorder/{viewModel}")]
        public IHttpActionResult ChangeOrder(SortVM viewModel)
        {
            try
            {
                return Ok(presidentRepository.ChangeOrder(viewModel));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
