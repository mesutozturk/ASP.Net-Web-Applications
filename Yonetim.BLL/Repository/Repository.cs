using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yonetim.DAL;
using Yonetim.Model.Entities;
using Yonetim.Model.ViewModels;

namespace Yonetim.BLL.Repository
{
    public class KategoriRepo : RepositoryBase<Kategori, int> { }

    public class HaberRepo : RepositoryBase<Haber, int>
    {
        public void Insert(HaberViewModel model)
        {
            MyContext db = new MyContext();
            using (db.Database.BeginTransaction())
            {
                try
                {
                    var kategoriler = db.Kategoriler
                                .Where(x => model.Kategoriler.Contains(x.Id))
                                .ToList();
                    var yeniHaber = new Haber()
                    {
                        Baslik = model.Baslik,
                        Icerik = model.Icerik,
                        Keywords = model.Keywords
                    };
                    db.Haberler.Add(yeniHaber);
                    db.SaveChanges();
                    yeniHaber.Kategoriler.AddRange(kategoriler);
                    db.SaveChanges();
                    db.Database.CurrentTransaction.Commit();
                }
                catch (Exception e)
                {
                    db.Database.CurrentTransaction.Rollback();
                }
            }
        }

        public void Update(HaberViewModel model)
        {
            MyContext db = new MyContext();
            using (db.Database.BeginTransaction())
            {
                try
                {
                    var haber = db.Haberler.Find(model.Id);
                    if (haber == null)
                        throw new DbEntityValidationException("Güncellenecek haber bulunamadı");

                    var kategoriler = db.Kategoriler
                        .Where(x => model.Kategoriler.Contains(x.Id))
                        .ToList();

                    haber.Baslik = model.Baslik;
                    haber.Icerik = model.Icerik;
                    haber.Keywords = model.Keywords;
                    haber.YayindaMi = model.YayindaMi;
                    db.SaveChanges();

                    haber.Kategoriler.Clear();
                    haber.Kategoriler = kategoriler;
                    db.SaveChanges();

                    db.Database.CurrentTransaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    db.Database.CurrentTransaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
