using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCHomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{

        public override void Delete(客戶聯絡人 entity)
        {
            entity.is刪除 = true;
        }
        public 客戶聯絡人 Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Update(客戶聯絡人 cust)
        {
            this.UnitOfWork.Context.Entry(cust).State = EntityState.Modified;
        }

    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}