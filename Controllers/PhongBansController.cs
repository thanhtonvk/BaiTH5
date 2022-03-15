using BaiTH5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiTH5.Controllers
{
    public class PhongBansController : ApiController
    {
        DBContext db = new DBContext();
        public IHttpActionResult PostPhongBan([FromBody] PhongBan phongBan)
        {
            db.AddPhongBan(phongBan.TenPB);
            db.SaveChanges();
            return Ok(db.GetPhongBan());
        }
        public IHttpActionResult PutPhongBan([FromBody]PhongBan phongBan)
        {
            db.UpdatePhongBan(phongBan.MaPB, phongBan.TenPB);
            db.SaveChanges();
            return Ok(db.GetPhongBan());
        }
        public IHttpActionResult DeletePhongBan(int mapb)
        {
            db.DeletePhongBan(mapb);
            db.SaveChanges();
            return Ok(db.GetPhongBan());
        }
        public IQueryable GetPhongBan()
        {
            return db.GetPhongBan();
        }
    }
}
