using BaiTH5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiTH5.Controllers
{
    public class NhanViensController : ApiController
    {
        DBContext db = new DBContext();
        [HttpPost]
        [Route("api/nhanviens")]
        public IHttpActionResult AddNhanVien([FromBody]NhanVien nhanVien)
        {
            db.NhanViens.Add(nhanVien);
            db.SaveChanges();
            return Ok(db.GetNhanVien());
        }
        [HttpPut]
        [Route("api/nhanviens")]
        public IHttpActionResult UpdateNhanVien([FromBody]NhanVien nhanVien)
        {
            db.UpdateNhanVien(nhanVien.MaNV, nhanVien.NgaySinh, nhanVien.GioiTinh, nhanVien.DiaChi, nhanVien.MaPB);
            db.SaveChanges();
            return Ok(db.GetNhanVien());
        }
        [HttpDelete]
        [Route("api/nhanviens")]
        public IHttpActionResult DeleteNhanVien(int MaNV)
        {
            db.DeleteNhanVien(MaNV);
            db.SaveChanges();
            return Ok(db.GetNhanVien());
        }
        [HttpGet]
        [Route("api/nhanviens")]
        public IQueryable GetNhanVien()
        {
            return db.GetNhanVien();
        }
        [HttpGet]
        [Route("api/nhanviens/getnhanvienbygioitinh")]
        public IQueryable GetNhanVienByGioiTinh(string gioitinh)
        {
            return db.GetNhanVienByGioiTinh(gioitinh);
        }
        [HttpGet]
        [Route("api/nhanviens/getnhanvienbydotuoi")]
        public IQueryable GetNhanVienByDoTuoi(int min, int max)
        {
            return db.GetNhanVietByDoTuoi(min, max);
        }
        [HttpGet]
        [Route("api/nhanviens/getnhanvienbyten")]
        public IQueryable GetNhanVienByTen(string ten)
        {
            return db.GetNhanVienByTen(ten);
        }

        [HttpGet]
        [Route("api/nhanviens/getnhanvienbydiachi")]
        public IQueryable GetNhanVienByDiaChi(string diachi)
        {
            return db.GetNhanVienByDiaChi(diachi);
        }
        [HttpGet]
        [Route("api/nhanviens/getnhanvienbyphongban")]
        public IQueryable GetNhanVienByPhongBan(string phongban)
        {
            return db.GetNhanVienByPhongBan(phongban);
        }


    }
}
