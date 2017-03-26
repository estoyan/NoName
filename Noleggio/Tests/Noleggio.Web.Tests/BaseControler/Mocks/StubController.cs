using Noleggio.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noleggio.Services.Contracts;
using System.Web.Routing;

namespace Noleggio.Web.Tests.BaseControlerTests.Mocks
{
    public class StubController : BaseController
    {
        public StubController(ICategoryService categoryService) : base(categoryService)
        {
            
        }

        public void BeginExecuteFromChild(RequestContext requestContext, AsyncCallback callback, object state)
        {
            base.BeginExexuteCall( requestContext, callback, state);
       }
    }
}
