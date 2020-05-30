using BG.Core.Entities;
using BG.Core.Repositories;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial platform controller.
	/// </summary>
	[RoutePrefix("platform")]
	[Authorize(Roles = Role.Admin)]
	public partial class PlatformController : BaseController
	{
		private ILogsRepository _logsRepository = null;
		private IUsersRepository _usersRepository = null;
       
        private IContactsRepository _contactsRepository = null;

        


        /// <summary>
        /// Constructor method.
        /// </summary>
        public PlatformController(ILogsRepository logsRepository, 
            IUsersRepository usersRepository,
                      
            IContactsRepository contactsRepository
            
            )
		{
			_logsRepository = logsRepository;
			_usersRepository = usersRepository;
            
            
            
        }
	}
}
