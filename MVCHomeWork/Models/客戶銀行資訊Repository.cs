using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCHomeWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{

        public override IQueryable<客戶銀行資訊> All()
        {
            return this.All().Include(客 => 客.客戶資料).Where(c => c.is刪除 != true);
        }

        public IQueryable<客戶銀行資訊> Search(string key)
        {
            return this.All().Where(s => s.銀行名稱.Contains(key));
        }


        public override void Delete(客戶銀行資訊 entity)
        {
            entity.is刪除 = true;
        }


        public 客戶銀行資訊 Find(int? id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Update(客戶銀行資訊 cust)
        {
            this.UnitOfWork.Context.Entry(cust).State = EntityState.Modified;
        }

    }

    public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}