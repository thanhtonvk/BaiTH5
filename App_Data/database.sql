use master
go
create database BaiTH5
go
use BaiTH5
go
create table PhongBan(
    MaPB int identity (1000,1) primary key ,
    TenPB nvarchar(100)
)
go
create table NhanVien(
    MaNV int identity (1000,1) primary key ,
    HoTen nvarchar(50),
    NgaySinh date,
    GioiTinh nvarchar(3),
    DiaChi nvarchar(100),
    MaPB int not null constraint  fk_1 foreign key(MaPB) references PhongBan(MaPB)
)
go
create table CongTrinh(
    MaCT int identity (1000,1) primary key ,
    TenCT nvarchar(100),
    DiaDiem nvarchar(100),
    NgayCapGP date,
    NgayKC date
)
go
create table Cong(
    MaCT int not null constraint fk_3 foreign key(MaCT) references CongTrinh(MaCT),
    MaNV int not null constraint fk_2 foreign key(MaNV) references NhanVien(MaNV),
    SLNgayCong int
)
go
alter table Cong add constraint pk_1 primary key (MaCT,MaNV)
go
create proc AddNhanVien @HoTen nvarchar(30),@NgaySinh date,@GioiTinh nvarchar(3),@DiaChi nvarchar(100),@MaPB int
as
    begin 
        insert into NhanVien(HoTen,NgaySinh, GioiTinh, DiaChi, MaPB) values (@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@MaPB)
    end
go
create proc UpdateNhanVien @MaNV int,@NgaySinh date,@GioiTinh nvarchar(3),@DiaChi nvarchar(100),@MaPB int
as 
    begin 
        update NhanVien set GioiTinh = @GioiTinh,NgaySinh = @NgaySinh,DiaChi = @DiaChi,MaPB = @MaPB
        where MaNV = @MaNV
    end
go
create proc DeleteNhanVien @MaNV int
as
    begin 
        delete from NhanVien where MaNV=@MaNV
    end
go
create function GetNhanVien()
returns table
as 
    return select * from NhanVien
go
create function GetNhanVienByGioiTinh(@gioitinh nvarchar(3))
returns table
as 
    return select * from NhanVien where GioiTinh=@gioitinh
go
alter function GetNhanVietByDoTuoi(@min int,@max int)
returns table
as
    return select * from NhanVien where year(getdate())-year(NhanVien.NgaySinh)>=@min and year(getdate())-year(NhanVien.NgaySinh)<=@max
go
create function GetNhanVienByTen(@ten nvarchar(30))
returns table 
as 
    return select * from NhanVien where NhanVien.HoTen like N'%'+@ten+'%'
go


create function GetNhanVienByDiaChi(@diachi nvarchar(100))
returns table 
as 
    return select * from NhanVien where DiaChi like N'%'+@diachi+'%'
go
create function GetNhanVienByPhongBan(@tenpb nvarchar(50))
returns table 
as 
    return select MaNV,HoTen,NgaySinh,GioiTinh,DiaChi,NhanVien.MaPB from NhanVien,PhongBan where NhanVien.MaPB = PhongBan.MaPB and TenPB like N'%'+@tenpb+'%'
go

create proc AddPhongBan @tenpb nvarchar(50)
as 
    begin 
        insert into PhongBan(TenPB) values (@tenpb)
    end
go
create proc  UpdatePhongBan @mapb int,@tenpb nvarchar(50)
as
    begin 
        update PhongBan set TenPB = @tenpb where MaPB = @mapb
    end
go
create proc DeletePhongBan @mapb int
as
    begin
        delete from PhongBan where MaPB = @mapb;
    end
go
create function GetPhongBan()
returns table
as 
    return select * from PhongBan
go
create proc AddCongTrinh @ten nvarchar(100),@diadiem nvarchar(100),@ngaycap date,@ngaykc date
as
    begin 
        insert into CongTrinh(TenCT,DiaDiem,NgayCapGP,NgayKC) values (@ten,@diadiem,@ngaycap,@ngaykc)
    end
go
create proc UpdateCongTrinh @mact int,@ten nvarchar(100),@diadiem nvarchar(100),@ngaycap date,@ngaykc date
as
    begin 
        update CongTrinh set TenCT = @ten,DiaDiem = @diadiem,NgayKC = @ngaykc,NgayCapGP = @ngaycap where MaCT = @mact
    end
go
create proc DeleteCongTrinh @mact int
as
    begin
        delete from CongTrinh where MaCT = @mact;
    end
go
create proc AddCong @MaCT int,@MaNV int,@SLNgayCong int
as
    begin 
        insert into Cong values (@MaCT,@MaNV,@SLNgayCong)
    end
go
create proc UpdateCong @MaCT int, @MaNV int, @SLNgayCong int
as 
    begin 
        update Cong set SLNgayCong = @SLNgayCong where MaCT = @MaCT and MaNV = @MaNV
    end
go
create proc DeleteCong @Mact int,@MaNV int
as 
    begin
        delete from Cong where MaCT= @Mact and MaNV = @MaNV;
    end


   


    
