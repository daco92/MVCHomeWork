using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCHomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
    {
        public override void Delete(客戶資料 entity)
        {
            entity.is刪除 = true;
        }

        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(c => c.is刪除 != true);
        }

        public IQueryable<客戶資料> Search(string keyword)
        {
            return base.All().Where(s => s.客戶名稱.Contains(keyword)).Where(c => c.is刪除 != true);
        }

        public 客戶資料 Get單筆資料ById(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Update(客戶資料 cust)
        {
            this.UnitOfWork.Context.Entry(cust).State = EntityState.Modified;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}