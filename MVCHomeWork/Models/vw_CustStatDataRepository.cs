using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCHomeWork.Models
{   
	public  class vw_CustStatDataRepository : EFRepository<vw_CustStatData>, Ivw_CustStatDataRepository
	{

	}

	public  interface Ivw_CustStatDataRepository : IRepository<vw_CustStatData>
	{

	}
}