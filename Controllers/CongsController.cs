using BaiTH5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiTH5.Controllers
{
    public class CongsController : ApiController
    {
        DBContext db = new DBContext();
        public IHttpActionResult PostCong([FromBody] Cong cong)
        {
            db.AddCong(cong.MaCT,cong.MaNV,cong.SLNgayCong);
            db.SaveChanges();
            return Ok(db.Congs);
        }
        public IHttpActionResult PutCong([FromBody] Cong cong)
        {
            db.AddCong(cong.MaCT, cong.MaNV, cong.SLNgayCong);
            db.SaveChanges();
            return Ok(db.Congs);
        }
        public IHttpActionResult DeleteCong(int mact,int manv)
        {
            db.DeleteCong(mact,manv);
            db.SaveChanges();
            return Ok(db.Congs);
        }
        public IQueryable GetCong()
        {
            return db.Congs;
        }
    }
}
