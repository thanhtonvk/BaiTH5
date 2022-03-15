using BaiTH5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiTH5.Controllers
{
    public class CongTrinhsController : ApiController
    {
        DBContext db = new DBContext();
        public IHttpActionResult PostCongTrinh([FromBody] CongTrinh congTrinh)
        {
            db.AddCongTrinh(congTrinh.TenCT, congTrinh.DiaDiem, congTrinh.NgayCapGP, congTrinh.NgayKC);
            db.SaveChanges();
            return Ok(db.CongTrinhs);
        }
        public IHttpActionResult PutCongTrinh([FromBody] CongTrinh congTrinh)
        {
            db.UpdateCongTrinh(congTrinh.MaCT,congTrinh.TenCT, congTrinh.DiaDiem, congTrinh.NgayCapGP, congTrinh.NgayKC);
            db.SaveChanges();
            return Ok(db.CongTrinhs);
        }
        public IHttpActionResult DeleteCongTrinh(int MaCt)
        {
            db.DeleteCongTrinh(MaCt);
            db.SaveChanges();
            return Ok(db.CongTrinhs);
        }
        public IQueryable GetCongTrinh()
        {
            return db.CongTrinhs;
        }
    }
}
