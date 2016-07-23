using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts;

namespace Photocom.BusinessLogic.Controllers
{
    public class BaseProcessor
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected BaseProcessor()
        {
            
        }

        protected BaseProcessor(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
