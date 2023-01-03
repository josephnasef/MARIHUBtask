using Microsoft.EntityFrameworkCore;
using MARIHUBtask.Domin.Context;
using MARIHUBtask.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Repository.Concert
{
    public class Repository<TEtity> : IRepository<TEtity> where TEtity : class
    {
        protected MARIHUBtaskContext _MARIHUBtaskContext { get; set; }
        public Repository(MARIHUBtaskContext MARIHUBtaskContext)
        {
            this._MARIHUBtaskContext = MARIHUBtaskContext;

        }
        public TEtity Add(TEtity entity)
        {
            _MARIHUBtaskContext.Set<TEtity>().Add(entity);
            return _MARIHUBtaskContext.SaveChanges() > 0 ? entity : null;
        }
        public async Task<TEtity> AddAsync(TEtity entity)
        {
            var result = await _MARIHUBtaskContext.Set<TEtity>().AddAsync(entity);
            return await _MARIHUBtaskContext.SaveChangesAsync() > 0 ? entity : null;
        }
        public TEtity GetBy(params object[] Id)
        {
            var MyObject = _MARIHUBtaskContext.Set<TEtity>().Find(Id);
            return MyObject;
        }
        public async Task<TEtity> GetByAsync(params object[] Id)
        {
            //var MyObject = await _BloggerContext.Set<TEtity>().FindAsync(Id);
            return await _MARIHUBtaskContext.Set<TEtity>().FindAsync(Id);
        }
        public List<TEtity> GetAllBind()
        {
            return GetAll().ToList();
        }
        public IEnumerable<TEtity> GetAll()
        {
            return this._MARIHUBtaskContext.Set<TEtity>().AsNoTracking();
        }
        public async Task<IEnumerable<TEtity>> GetAllAsyn()
        {
            return await this._MARIHUBtaskContext.Set<TEtity>().ToListAsync(); ;
        }
        public IQueryable<TEtity> GetAllQurAsync()
        {
            return this._MARIHUBtaskContext.Set<TEtity>();
        }
        public TEtity RemoveById(params object[] Id)
        {
            var entity = GetBy(Id);
            _MARIHUBtaskContext.Set<TEtity>().Remove(GetBy(Id));

            return _MARIHUBtaskContext.SaveChanges() > 0 ? entity : null;
        }
        public TEtity Remove(TEtity entity)
        {
            _MARIHUBtaskContext.Set<TEtity>().Remove(entity);

            return _MARIHUBtaskContext.SaveChanges() > 0 ? entity : null;
        }
        public async Task<TEtity> RemoveByIdAsync(params object[] Id)
        {
            var entity = await _MARIHUBtaskContext.Set<TEtity>().FindAsync(Id);
            _MARIHUBtaskContext.Set<TEtity>().Remove(entity);
            return await _MARIHUBtaskContext.SaveChangesAsync() > 0 ? entity : null;
        }
        public TEtity Update(TEtity entity)
        {
            _MARIHUBtaskContext.Set<TEtity>().Update(entity);
            return _MARIHUBtaskContext.SaveChanges() > 0 ? entity : null;
        }
        public async Task<TEtity> UpdateAsync(TEtity entity)
        {
            _MARIHUBtaskContext.Set<TEtity>().Update(entity);
            return await _MARIHUBtaskContext.SaveChangesAsync() > 0 ? entity : null;
        }
        public void Save()
        {
            _MARIHUBtaskContext.SaveChanges();
        }       
    }
}

